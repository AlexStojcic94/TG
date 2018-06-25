﻿using GeoAPI.CoordinateSystems;
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
using System.IO;

namespace TG
{
    public partial class Form1 : Form
    {

        private static AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
        private int dragStartX;
        private int dragStartY;
        private bool appIntersectionState;

        private void Form1_Load(object sender, EventArgs e) { }
        public Form1()
        {
            InitializeComponent();

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

        private void Intersection_Click(object sender, EventArgs e)
        {
            {
                if (this.intersection.Text == "Find Intersection")
                { 
                    appIntersectionState = true;
                    this.intersection.Text = "OK";
                    Layers.layers.removeIntersectionLayer();
                    Layers.layers.intersectionPoints.RemoveRange(0, Layers.layers.intersectionPoints.Count);
                    Map.Image = Layers.layers.getMap();
                }
                else
                {
                    appIntersectionState = false;
                this.intersection.Text = "Find Intersection";
                    Map.Image = Layers.layers.getIntersection();
                    this.intersection.Text = "Find Intersection";
                    int i = Map.Controls.Count;
                    for (int j = 0; j < i; j++)
                    {
                        Map.Controls.RemoveAt(0);
                    }
                }
            }
        }
        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
                if (appIntersectionState)
                {
                    Layers.layers.insertIntersectionPoint(e.X, e.Y);
                    PictureBox point = new PictureBox();
                    Map.Controls.Add(point);
                    point.Image = Image.FromFile(Directory.GetCurrentDirectory().Replace('\\', '/') + "/pic/point.png");
                    point.Location = new System.Drawing.Point(e.X - 10, e.Y - 15);
                    point.Height = 30;
                    point.Width = 20;
                    point.BackColor = Color.Transparent;
                    point.SizeMode = PictureBoxSizeMode.StretchImage;
                    point.BringToFront();
                }
        }

        private void Service_CheckedChanged(object sender, EventArgs e)
        {
            PointsTypes.toggleServiceLayer(Service.Checked);
            Map.Image = Layers.layers.getMap();
        }

        private void Utility_CheckedChanged(object sender, EventArgs e)
        {
            PointsTypes.toggleUtilityLayer(Utility.Checked);
            Map.Image = Layers.layers.getMap();
        }

        private void Inn_CheckedChanged(object sender, EventArgs e)
        {
            PointsTypes.toggleInnLayer(Inn.Checked);
            Map.Image = Layers.layers.getMap();
        }

        private void Transportation_CheckedChanged(object sender, EventArgs e)
        {
            PointsTypes.toggleTransportationLayer(Transportation.Checked);
            Map.Image = Layers.layers.getMap();
        }

        private void Cultural_CheckedChanged(object sender, EventArgs e)
        {
            PointsTypes.toggleCulturalLayer(Cultural.Checked);
            Map.Image = Layers.layers.getMap();
        }

        private void Tourist_CheckedChanged(object sender, EventArgs e)
        {
            PointsTypes.toggleTouristLayer(Tourist.Checked);
            Map.Image = Layers.layers.getMap();
        }
    }
}
