using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoAPI.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using GeoAPI.CoordinateSystems.Transformations;
using SharpMap.Data.Providers;

namespace TG
{
    public class Layers
    {
        private static Layers _layers = null;

        private static string connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=admin;Database=TG;";
        private static string geomname = "geom";
        private static string idname = "gid";
        private static string intersectionQuery = "";
        private static string distanceQuery = "";
        private static float distance = 0.001f;
        private static string searchName = "";
        

        private static List<String> placesTypes = new List<string>(new string[] { "city", "town", "suburb", "village", "neighbourhood", "isolated_dwellin", "locality"  });
        private static SharpMap.Layers.VectorLayer routingLayer = new SharpMap.Layers.VectorLayer("Routing");
        private static SharpMap.Layers.LabelLayer placesLayer = new SharpMap.Layers.LabelLayer("Places");

        public bool showBuilding = false;
        public bool showRailways = false;
        public bool showPoints = false;
        public List<string> listDispley;

        public List<GeoAPI.Geometries.Coordinate> intersectionPoints = new List<GeoAPI.Geometries.Coordinate>();
        
        SharpMap.Map _sharpMap;

        private Layers()
        {
            _sharpMap = new SharpMap.Map(new Size(802, 362));
            _sharpMap.BackColor = Color.FromArgb(232, 232, 232);

            SharpMap.Layers.VectorLayer landuseLayer = new SharpMap.Layers.VectorLayer("Landuse");
            landuseLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "landuse", geomname, idname);
            landuseLayer.Style.Fill = new SolidBrush(Color.FromArgb(192, 236, 174));
            landuseLayer.Style.Outline = Pens.Green;
            landuseLayer.Style.EnableOutline = true;
            _sharpMap.Layers.Add(landuseLayer);

            SharpMap.Layers.VectorLayer roadsLayer = new SharpMap.Layers.VectorLayer("Roads");
            roadsLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "nis_routing", "geom_way", "id");
            roadsLayer.Style.Line.Width = 1;
            roadsLayer.Style.Line.Color = Color.WhiteSmoke;
            _sharpMap.Layers.Add(roadsLayer);

            setPlacesLayer();

            SharpMap.Layers.VectorLayer buildingsLayer = new SharpMap.Layers.VectorLayer("Buildings");
            buildingsLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "buildings", geomname, idname);
            buildingsLayer.Style.Fill = new SolidBrush(Color.FromArgb(192, 236, 174));
            buildingsLayer.Style.Outline = Pens.Green;
            buildingsLayer.Enabled = false;
            _sharpMap.Layers.Add(buildingsLayer);

            SharpMap.Layers.VectorLayer railwaysLayer = new SharpMap.Layers.VectorLayer("Railways");
            railwaysLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "railways", geomname, idname);
            railwaysLayer.Style.Line.Width = 1;
            railwaysLayer.Style.Line.Color = Color.DarkGray;
            railwaysLayer.Enabled = false;
            _sharpMap.Layers.Add(railwaysLayer);

            PointsTypes.init(_sharpMap, "");

            _sharpMap.ZoomToExtents();
            
        }
        public static Layers layers
        {
            get
            {
                if (_layers == null)
                {
                    _layers = new Layers();
                }
                return _layers;
            }
        }
        
        public double getCurrentZoom()
        {
            return _sharpMap.Zoom;
        }
        public Image getMap()
        {
            return _sharpMap.GetMap();
        }
        
        public List<string> getRoadNames()
        {
            string queryString1 = "select osm_name from nis_routing";
            List<string> list = new List<string>();

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = new NpgsqlCommand(queryString1, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(LaToCy.CyToLaConverter.Translit(reader[0].ToString()));
                    }
                }

                connection.Close();
            }

            return list;
        }
        public string findRoadSource(string name)
        {
            string Source = null;

            string queryString1 = "select source from nis_routing where osm_name in ('" + LaToCy.LaToCyConverter.Translit(name) + "','" + name + "')";

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = new NpgsqlCommand(queryString1, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Source = reader[0].ToString();
                    }
                }

                connection.Close();
            }

            return Source;
        }
        public Image searchRoute(string street1, string street2)
        {
            _sharpMap.Layers.Remove(routingLayer);
            string Source1 = street1 != null ? findRoadSource(street1) : null;
            string Source2 = street2 != null ? findRoadSource(street2) : null;

            if (Source1 != null && Source2 != null)
            {
                var queryic = " id in (SELECT id2 FROM pgr_dijkstra('SELECT id, source, target, cost, reverse_cost " +
                    "FROM nis_routing', " + Source1 + ", " + Source2 + ", false, true))";

                var provajder = new SharpMap.Data.Providers.PostGIS(connString, "nis_routing", "geom_way", "id");
                provajder.DefinitionQuery = queryic;
                routingLayer.DataSource = provajder;
                routingLayer.Enabled = true;

                routingLayer.Style.Line.Width = 1;
                routingLayer.Style.Line.Color = Color.Red;
                _sharpMap.Layers.Add(routingLayer);
            }

            return getMap();
        }
        public void setPlacesLayer()
        {
            _sharpMap.Layers.Remove(placesLayer);

            var queryic = " type in (";
            for (int i = 0; i < ZoomRegulator.zoomRegulator.zoom_level + 1; ++i)
            {
                queryic += "'" + placesTypes[i] + "', ";
            }
            queryic = queryic.Remove(queryic.Count() - 2, 2) + ")";

            var provajder = new SharpMap.Data.Providers.PostGIS(connString, "places", geomname, idname);
            provajder.DefinitionQuery = queryic;

            placesLayer.DataSource = provajder;
            placesLayer.LabelColumn = "name";

            SharpMap.Styles.LabelStyle min = new SharpMap.Styles.LabelStyle();
            SharpMap.Styles.LabelStyle max = new SharpMap.Styles.LabelStyle();
            min.CollisionDetection = true;
            max.CollisionDetection = true;
            min.CollisionBuffer = new SizeF(25, 25);
            max.CollisionBuffer = new SizeF(25, 25);
            min.Font = new Font(FontFamily.Families.Where(x => x.Name == "Arial").FirstOrDefault(), 14 - ZoomRegulator.zoomRegulator.zoom_level * 0.7f, FontStyle.Italic);
            max.Font = new Font(FontFamily.Families.Where(x => x.Name == "Arial").FirstOrDefault(), 14 - ZoomRegulator.zoomRegulator.zoom_level * 0.7f, FontStyle.Italic);
            min.ForeColor = Color.DarkGray;
            max.ForeColor = Color.Black;
            placesLayer.Theme = new SharpMap.Rendering.Thematics.GradientTheme("population",0,202250,min,max);
      
            _sharpMap.Layers.Add(placesLayer);
            
        }
        public string getCoordinates(int X, int Y)
        {
            GeoAPI.Geometries.Coordinate p = _sharpMap.ImageToWorld(new PointF(X, Y));
            PointF pUTM = new PointF();

            IProjectedCoordinateSystem utmProj = Helpers.CoordinateSystem.CreateUtmProjection(34);
            IGeographicCoordinateSystem geoCS = utmProj.GeographicCoordinateSystem;
            CoordinateTransformationFactory ctFac = new CoordinateTransformationFactory();
            ICoordinateTransformation transform = ctFac.CreateFromCoordinateSystems(geoCS, utmProj);
            double[] c = new double[2];
            c[0] = p.X; c[1] = p.Y;
            c = transform.MathTransform.Transform(c);
            pUTM.X = (float)c[0]; pUTM.Y = (float)c[1];
            
            return pUTM.X + " : " + pUTM.Y;
        }
        public Image changeRailwaysVisibility()
        {
            var railways_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Railways").FirstOrDefault();
            if (railways_Layer != null)
            {
                if (showRailways == false)
                {
                    showRailways = true;
                    railways_Layer.Enabled = true;

                }
                else
                {
                    showRailways = false;
                    railways_Layer.Enabled = false;
                }
            }

            return getMap();
        }
        public Image changeBuildingsVisibility()
        {
            var buildings_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Buildings").FirstOrDefault();
            if (buildings_Layer != null)
            {
                if (showBuilding == false)
                {
                    showBuilding = true;

                    if (ZoomRegulator.zoomRegulator.showBuilding)
                    {
                        buildings_Layer.Enabled = true;
                    }

                }
                else
                {
                    showBuilding = false;
                    buildings_Layer.Enabled = false;
                }
            }

            return getMap();
        }
        public Image recenterMap(int X, int Y)
        {
            GeoAPI.Geometries.Coordinate p = _sharpMap.ImageToWorld(new PointF(X, Y));
            _sharpMap.Center.X = p.X;
            _sharpMap.Center.Y = p.Y;

            return getMap();
        }
        public void toggleBuildings(bool enabled)
        {
            var buildings_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Buildings").FirstOrDefault();
            if (buildings_Layer != null)
                buildings_Layer.Enabled = showBuilding && enabled;
        }
        public void togglePoints(bool enabled)
        {
            var points_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Points").FirstOrDefault();
            if (points_Layer != null)
                points_Layer.Enabled = showPoints && enabled;
        }
        public void changeZoom(float zoomFactor)
        {
            _sharpMap.Zoom = _sharpMap.Zoom * zoomFactor;
            setPlacesLayer();
        }
        public Image getIntersection()
        {
            if (intersectionPoints.Count > 2)
            {
                int i = 0;
                string polygon = "POLYGON((";
                for(i = 0; i < intersectionPoints.Count; i++)
                {
                    polygon += intersectionPoints[i].X + " " + intersectionPoints[i].Y + ",";
                }
                polygon += intersectionPoints[0].X + " " + intersectionPoints[0].Y + "))";  
                intersectionQuery = " AND ST_Intersects(geom, ST_GeomFromText('"+polygon+"',3005))";

                PointsTypes.init(_sharpMap, intersectionQuery + distanceQuery);
                listDispley = PointsTypes.queryPoints(intersectionQuery + distanceQuery);

                intersectionPoints.RemoveRange(0, intersectionPoints.Count);
            }
          
            return getMap();
        }
        public void queryPoints()
        {
            listDispley = PointsTypes.queryPoints(intersectionQuery + distanceQuery);
        }
        public void insertIntersectionPoint(float X, float Y)
        {
            GeoAPI.Geometries.Coordinate pt = _sharpMap.ImageToWorld(new PointF(X,Y));
            intersectionPoints.Add(pt);
        }
        public void removeIntersectionLayer()
        {
            var intersection_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Intersection").FirstOrDefault();
            if (intersection_Layer != null)
                _sharpMap.Layers.Remove(intersection_Layer);
        }
        public Image SearchPointsByName(string name, float _distance)
        {
            _sharpMap.Layers.Remove(PointsTypes.searchLayer);
            _sharpMap.Layers.Add(PointsTypes.search(name));

            searchName = name;
            distance = ((float)_distance) / 5000;
            distanceQuery = PointsTypes.formDistanceQuery(name, distance);

            PointsTypes.init(_sharpMap, intersectionQuery + distanceQuery);
            listDispley = PointsTypes.queryPoints(intersectionQuery + distanceQuery);

            return getMap();
        }
        public Image changeDistance(int _distance)
        {
            distance = ((float)_distance) / 5000;
            distanceQuery = PointsTypes.formDistanceQuery(searchName, distance);
            PointsTypes.init(_sharpMap, intersectionQuery + distanceQuery);
            listDispley = PointsTypes.queryPoints(intersectionQuery + distanceQuery);

            return getMap();
        }
        public string getDisplayDistance(string gid)
        {
            return PointsTypes.getLabelInfo(searchName, gid);
        }
    }
}
