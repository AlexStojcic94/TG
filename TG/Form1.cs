using System;
using System.Collections.Generic;
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
        const String DATA_NAME = "ROADS";
        const String DATA_PATH = @"C:\Users\alexstojcic\source\repos\TG\TG\bin\Debug\world_adm0\roads.shp";

        public Form1()
        {
            InitializeComponent();
            _sharpMap = new SharpMap.Map(new Size(648, 248));
            _sharpMap.BackColor = Color.White;

            SharpMap.Layers.VectorLayer roadsLayer = new SharpMap.Layers.VectorLayer(DATA_NAME);
            roadsLayer.DataSource = new SharpMap.Data.Providers.ShapeFile(DATA_PATH);

            _sharpMap.Layers.Add(roadsLayer);

            _sharpMap.ZoomToExtents();

            pictureBox1.Image = _sharpMap.GetMap();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
