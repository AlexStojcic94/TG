using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        string roadsTableName = "roads";
        string geomname = "geom";
        string idname = "gid";

        public Form1()
        {
            InitializeComponent();
            _sharpMap = new SharpMap.Map(new Size(802, 362));
            _sharpMap.BackColor = Color.White;


            SharpMap.Layers.VectorLayer roadsLayer = new SharpMap.Layers.VectorLayer("Roads");
            roadsLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, roadsTableName, geomname, idname);
            
            _sharpMap.Layers.Add(roadsLayer);

            _sharpMap.ZoomToExtents();

            Map.Image = _sharpMap.GetMap();

        }

        

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom_level < 6)
            {
                zoom_level += 1;
                _sharpMap.Zoom = _sharpMap.Zoom * ZOOM_FACTOR;
                Map.Image = _sharpMap.GetMap();
            }
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
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
    }
}
