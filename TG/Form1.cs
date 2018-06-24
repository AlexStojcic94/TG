using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using Npgsql;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using SharpMap.Data;
using NetTopologySuite.Geometries;
using GeoAPI.Geometries;
using SharpMap.Data.Providers;

namespace TG
{
    public partial class Form1 : Form
    {
        SharpMap.Map _sharpMap;
        const float ZOOM_FACTOR = 0.3f;
        int zoom_level = 1;
        string connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=admin;Database=TG;";
        string geomname = "geom";
        string idname = "gid";
        bool showBuilding = false;
        bool showRailways = false;
        bool showLandmarks = false;
        static List<String> tables = new List<string>(new string[] {"places", "buildings","points", "landuse", } );
        AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
        SharpMap.Layers.VectorLayer routingLayer = new SharpMap.Layers.VectorLayer("Routing");

        public Form1()
        {
            InitializeComponent();
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
            placesLayer.Style.CollisionBuffer = new SizeF(25, 25);
            placesLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.First;
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

            Map.Image = _sharpMap.GetMap();

            initSearch();
            initRoadSearch();
        }



        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom_level == 2 && showBuilding)
            {
                var buildings_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Buildings").FirstOrDefault();
                if (buildings_Layer != null)
                {
                    buildings_Layer.Enabled = true;
                }
            }
            if (zoom_level == 4 && showLandmarks)
            {
                var points_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Points").FirstOrDefault();
                if (points_Layer != null)
                    points_Layer.Enabled = true;
            }
            if (zoom_level < 6)
            {
                zoom_level += 1;
                _sharpMap.Zoom = _sharpMap.Zoom * ZOOM_FACTOR;
                Map.Image = _sharpMap.GetMap();
            }

        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom_level == 3 && showBuilding)
            {
                var buildings_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Buildings").FirstOrDefault();
                if (buildings_Layer != null)
                    buildings_Layer.Enabled = false;
            }
            if (zoom_level == 5 && showLandmarks)
            {
                var points_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Points").FirstOrDefault();
                if (points_Layer != null)
                    points_Layer.Enabled = false;
            }
            if (zoom_level > 1)
            {
                zoom_level--;
                _sharpMap.Zoom = _sharpMap.Zoom / ZOOM_FACTOR;
                Map.Image = _sharpMap.GetMap();
            }

        }



        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            GeoAPI.Geometries.Coordinate p = _sharpMap.ImageToWorld(new PointF(e.X, e.Y));
            _sharpMap.Center.X = p.X;
            _sharpMap.Center.Y = p.Y;

            Map.Image = _sharpMap.GetMap();

        }

        private void Buildings_CheckedChanged(object sender, EventArgs e)
        {
            var buildings_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Buildings").FirstOrDefault();
            if (buildings_Layer != null)
            {
                if (showBuilding == false)
                {

                    showBuilding = true;

                    if (zoom_level >= 3)
                    {
                        buildings_Layer.Enabled = true;
                        Map.Image = _sharpMap.GetMap();
                    }

                }
                else
                {
                    showBuilding = false;
                    buildings_Layer.Enabled = false;
                    Map.Image = _sharpMap.GetMap();
                }
            }
        }


        private void Railways_CheckedChanged(object sender, EventArgs e)
        {
            var railways_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Railways").FirstOrDefault();
            if (railways_Layer != null)
            {
                if (showRailways == false)
                {
                    showRailways = true;
                    railways_Layer.Enabled = true;
                    Map.Image = _sharpMap.GetMap();

                }
                else
                {
                    showRailways = false;
                    railways_Layer.Enabled = false;
                    Map.Image = _sharpMap.GetMap();
                }
            }
        }

        private void Points_CheckedChanged(object sender, EventArgs e)
        {
            var points_Layer = _sharpMap.Layers.Where(x => x.LayerName == "Points").FirstOrDefault();
            if (points_Layer != null)
            {
                if (showLandmarks == false)
                {

                    showLandmarks = true;

                    if (zoom_level >= 5)
                    {
                        points_Layer.Enabled = true;
                        Map.Image = _sharpMap.GetMap();
                    }

                }
                else
                {
                    showLandmarks = false;
                    points_Layer.Enabled = false;
                    Map.Image = _sharpMap.GetMap();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void initRoadSearch()
        {
            string queryString1 = "select osm_name from nis_routing";
            List<string> tempList = new List<string>();

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                var command = new NpgsqlCommand(queryString1, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempList.Add(LaToCy.CyToLaConverter.Translit(reader[0].ToString()));
                    }
                }

                connection.Close();
            }
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(tempList.ToArray());
            searchFrom.AutoCompleteCustomSource = autoComplete;
            searchTo.AutoCompleteCustomSource = autoComplete;
        }
        public string findRoadSource(string name)
        {
            string Source = null;

            string queryString1 = "select source from nis_routing where osm_name in ('" + LaToCy.LaToCyConverter.Translit(name) + "','" + name +"')";

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
        private void initSearch()
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
            allowedTypes.AddRange(list.ToArray());
            SearchByName.AutoCompleteCustomSource = allowedTypes;
        }
        

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            GeoAPI.Geometries.Coordinate p = _sharpMap.ImageToWorld(new PointF(e.X, e.Y));
            PointF pUTM = new PointF();

            IProjectedCoordinateSystem utmProj = Helpers.CoordinateSystem.CreateUtmProjection(34);
            IGeographicCoordinateSystem geoCS = utmProj.GeographicCoordinateSystem;
            CoordinateTransformationFactory ctFac = new CoordinateTransformationFactory();
            ICoordinateTransformation transform = ctFac.CreateFromCoordinateSystems(geoCS, utmProj);
            double[] c = new double[2];
            c[0] = p.X; c[1] = p.Y;
            c = transform.MathTransform.Transform(c);
            pUTM.X = (float)c[0]; pUTM.Y = (float)c[1];

            coordinates.Text = pUTM.X + " : " + pUTM.Y;            
        }

        private void SearchRoute_Click(object sender, EventArgs e)
        {
            _sharpMap.Layers.Remove(routingLayer);
            string Source1 = searchFrom.Text != null ? findRoadSource(searchFrom.Text) : null;
            string Source2 = searchTo.Text != null ? findRoadSource(searchTo.Text) : null;

            if (Source1 != null && Source2 != null)
            {
                var queryic = " id in (SELECT id2 FROM pgr_dijkstra('SELECT id, source, target, cost, reverse_cost " +
                    "FROM nis_routing', "+ Source1 + ", "+ Source2 + ", false, true))";

                var provajder = new SharpMap.Data.Providers.PostGIS(connString, "nis_routing", "geom_way", "id");
                provajder.DefinitionQuery = queryic;
                routingLayer.DataSource = provajder;
                routingLayer.Enabled = true;

                routingLayer.Style.Line.Width = 1;
                routingLayer.Style.Line.Color = Color.Red;
                _sharpMap.Layers.Add(routingLayer);
            }
            Map.Image = _sharpMap.GetMap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharpMap.Layers.VectorLayer buildingsLayer = new SharpMap.Layers.VectorLayer("Buildings");
            //buildingsLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "buildings", geomname, idname);
            SharpMap.Data.Providers.PostGIS prov = new PostGIS(connString, "waterways", geomname, idname);
            prov.DefinitionQuery = "ST_Intersects(geom, ST_GeomFromText('POLYGON((21.84164191 43.33574271,21.94017554 43.3348687, 21.94498206 43.29727457, 21.85880805 43.29252682, 21.84164191 43.33574271))',3005))";
            buildingsLayer.DataSource = prov;
            buildingsLayer.Style.Line.Width = 1;
            buildingsLayer.Style.Line.Color = Color.Blue;
            buildingsLayer.Enabled = true;
            _sharpMap.Layers.Add(buildingsLayer);
            Map.Image = _sharpMap.GetMap();
        }
        
    }
}
