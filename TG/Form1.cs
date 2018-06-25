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

        private static AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
        private int dragStartX;
        private int dragStartY;

        private void Form1_Load(object sender, EventArgs e){}
        public Form1()
        {
            InitializeComponent();
            //SharpMap.Layers.VectorLayer waterwaysLayer = new SharpMap.Layers.VectorLayer("Waterways");
            //waterwaysLayer.DataSource = new SharpMap.Data.Providers.PostGIS(connString, "waterways", geomname, idname);
            //waterwaysLayer.Style.Line.Width = 1;
            //waterwaysLayer.Style.Line.Color = Color.Blue;
            //_sharpMap.Layers.Add(waterwaysLayer);

            Map.Image = Layers.layers.getMap();


            initSearch();
            initRoadSearch();
        }



        private void ZoomIn_Click(object sender, EventArgs e)
        {
            Map.Image = ZoomRegulator.zoomRegulator.ZoomIn();
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            Map.Image = ZoomRegulator.zoomRegulator.ZoomOut();
        }
        


        private void Buildings_CheckedChanged(object sender, EventArgs e)
        {
            Map.Image = Layers.layers.changeBuildingsVisibility();
        }
        
        private void Railways_CheckedChanged(object sender, EventArgs e)
        {
            Map.Image = Layers.layers.changeRailwaysVisibility();
        }

        private void Points_CheckedChanged(object sender, EventArgs e)
        {
            Map.Image = Layers.layers.changePointsVisibility();
        }
        
        private void initRoadSearch()
        {
            var list = Layers.layers.getRoadNames();

            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(list.ToArray());
            searchFrom.AutoCompleteCustomSource = autoComplete;
            searchTo.AutoCompleteCustomSource = autoComplete;
        }

        private void initSearch()
        {
            var list = Layers.layers.getNames();

            allowedTypes.AddRange(list.ToArray());
            SearchByName.AutoCompleteCustomSource = allowedTypes;
        }
        
        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            coordinates.Text = Layers.layers.getCoordinates(e.X, e.Y);
            coordinates.Text = pUTM.X + " : " + pUTM.Y;            
        }

        private void SearchRoute_Click(object sender, EventArgs e)
        {
            Map.Image = Layers.layers.searchRoute(searchFrom.Text, searchTo.Text);
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            dragStartX = e.X;
            dragStartY = e.Y;
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            Map.Image = Layers.layers.recenterMap(dragStartX - e.X + Map.Size.Width / 2, dragStartY - e.Y + Map.Size.Height / 2);
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
