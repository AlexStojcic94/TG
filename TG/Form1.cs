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
        static List<String> tables = new List<string>(new string[] {"places", "buildings","points", "landuse", "roads", } );
        AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();


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
            roadsLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "roads", geomname, idname);
            roadsLayer.Style.Line.Width = 1;
            roadsLayer.Style.Line.Color = Color.WhiteSmoke;
            _sharpMap.Layers.Add(roadsLayer);

            SharpMap.Layers.VectorLayer waterwaysLayer = new SharpMap.Layers.VectorLayer("Waterways");
            waterwaysLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "waterways", geomname, idname);
            waterwaysLayer.Style.Line.Width = 1;
            waterwaysLayer.Style.Line.Color = Color.Blue;
            _sharpMap.Layers.Add(waterwaysLayer);

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

        private void SearchByName_KeyUp(object sender, KeyEventArgs e)
        {
            string queryString1 = "select name from ";
            string queryString2 = " where upper(name) like upper('" + SearchByName.Text + "%') or upper(name) like upper('" + LaToCy.LaToCyConverter.Translit(SearchByName.Text) + "%');";
            int i = 0;
            int totalCount = 0;

            using (var connection = new NpgsqlConnection(connString))
            {

                connection.Open();
                AutoCompleteStringCollection autoCol = new AutoCompleteStringCollection();

                while (totalCount < 10 && i < tables.Count())
                {

                    var command = new NpgsqlCommand(queryString1 + tables[i] + queryString2, connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (totalCount<10 && reader.Read())
                        {
                            autoCol.Add(reader[0].ToString());
                            totalCount ++;
                        }
                    }
                    ++i;
                }
                connection.Close();

                lock (SearchByName.AutoCompleteCustomSource.SyncRoot)
                {
                    SearchByName.AutoCompleteCustomSource = autoCol;
                }
                
            }
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
    }
}
