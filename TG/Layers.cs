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

        private static List<String> tables = new List<string>(new string[] { "places", "buildings", "points", "landuse", });
        private static SharpMap.Layers.VectorLayer routingLayer = new SharpMap.Layers.VectorLayer("Routing");

        private double MaxArea = 0;
        private double MinArea = 0;

        public bool showBuilding = false;
        public bool showRailways = false;
        public bool showPoints = false;

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

            //SharpMap.Layers.VectorLayer waterwaysLayer = new SharpMap.Layers.VectorLayer("Waterways");
            //waterwaysLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "waterways", geomname, idname);
            //waterwaysLayer.Style.Line.Width = 1;
            //waterwaysLayer.Style.Line.Color = Color.Blue;
            //_sharpMap.Layers.Add(waterwaysLayer);

            SharpMap.Layers.LabelLayer placesLayer = new SharpMap.Layers.LabelLayer("Places");
            placesLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "places", geomname, idname);
            placesLayer.LabelColumn = "name";
            placesLayer.Style.CollisionDetection = true;
            placesLayer.Style.CollisionBuffer = new SizeF(50, 50);
            placesLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
            placesLayer.Style.Font = new Font(FontFamily.GenericSansSerif, 8);
            _sharpMap.Layers.Add(placesLayer);


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

            SharpMap.Layers.LabelLayer pointsLayer = new SharpMap.Layers.LabelLayer("Points");
            pointsLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "points", geomname, idname);
            pointsLayer.LabelColumn = "name";
            pointsLayer.Style.CollisionDetection = true;
            pointsLayer.Style.CollisionBuffer = new SizeF(50, 50);
            pointsLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
            pointsLayer.Style.Font = new Font(FontFamily.GenericSansSerif, 8);
            pointsLayer.Enabled = false;
            _sharpMap.Layers.Add(pointsLayer);

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

        private void getAreas()
        {

            //string queryString1 = "select source from nis_routing where osm_name in ('" + LaToCy.LaToCyConverter.Translit(name) + "','" + name + "')";

            //using (var connection = new NpgsqlConnection(connString))
            //{
            //    connection.Open();

            //    var command = new NpgsqlCommand(queryString1, connection);
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            Source = reader[0].ToString();
            //        }
            //    }

            //    connection.Close();
            //}

            //return Source;
        }

        public Image getMap()
        {
            return _sharpMap.GetMap();
        }
        public List<string> getNames()
        {
            string queryString1 = "select name from ";
            int i = 0;
            List<string> list = new List<string>();

            using (var connection = new NpgsqlConnection(connString))
            {

                connection.Open();

                while (i < tables.Count())
                {
                    var command = new NpgsqlCommand(queryString1 + tables[i], connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(LaToCy.CyToLaConverter.Translit(reader[0].ToString()));
                        }
                    }
                    i++;
                }
                connection.Close();

            }

            return list;
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
        public Image changePointsVisibility()
        {
            var points_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Points").FirstOrDefault();
            if (points_Layer != null)
            {
                if (showPoints == false)
                {
                    showPoints = true;

                    if (ZoomRegulator.zoomRegulator.showPoints)
                    {
                        points_Layer.Enabled = true;
                    }

                }
                else
                {
                    showPoints = false;
                    points_Layer.Enabled = false;
                }
            }

            return getMap();
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
                string query = "ST_Intersects(geom, ST_GeomFromText('"+polygon+"',3005))";

                SharpMap.Layers.LabelLayer intersectionLayer = new SharpMap.Layers.LabelLayer("Intersection");
               
                SharpMap.Data.Providers.PostGIS prov = new PostGIS(connString, "points", geomname, idname);
                prov.DefinitionQuery = query;
                intersectionLayer.DataSource = prov;
                intersectionLayer.LabelColumn = "name";
              
                intersectionLayer.Style.ForeColor = Color.DarkOrange;
                intersectionLayer.Style.CollisionDetection = true;
                intersectionLayer.Style.CollisionBuffer = new SizeF(50, 50);
                intersectionLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
                intersectionLayer.Style.Font = new Font(FontFamily.GenericSansSerif, 8);
                intersectionLayer.Enabled = true;
                _sharpMap.Layers.Add(intersectionLayer);

                intersectionPoints.RemoveRange(0, intersectionPoints.Count);
            }
          
            return getMap();
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
    }
}
