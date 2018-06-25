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
using System.IO;

namespace TG
{
    public static class PointsTypes
    {

        private static string connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=admin;Database=TG;";
        private static string geomname = "geom";
        private static string idname = "gid";

        public static bool serviceTypeEnabled = false;
        public static bool utilityTypeEnabled = false;
        public static bool innTypeEnabled = false;
        public static bool transportationTypeEnabled = false;
        public static bool culturalTypeEnabled = false;
        public static bool touristActivityTypeEnabled = false;

        public static List<String> serviceTypes = new List<string>(new string[] { "police", "hospital", "doctors", "bank", "post_office", "pharmacy", "embassy" });
        public static List<String> utilityTypes = new List<string>(new string[] { "toilets", "drinking_water" });
        public static List<String> innTypes = new List<string>(new string[] { "camp_site", "hostel", "hotel"});
        public static List<String> transportationTypes = new List<string>(new string[] {"bus_stop", "parking", "bus_station", "taxi" });
        public static List<String> culturalTypes = new List<string>(new string[] { "museum","grave_yard", "archaeological_s", "memorial", "castle", "monument", "artwork", "arts_centre", "battlefield", "ruins", "place_of_worship" });
        public static List<String> touristActivityTypes = new List<string>(new string[] { "picnic_site", "viewpoint", "nightclub", "theatre", "cafe", "swimming_pool" });

        public static List<SharpMap.Layers.VectorLayer> serviceLayersList = new List<SharpMap.Layers.VectorLayer>();
        public static List<SharpMap.Layers.VectorLayer> utilityLayersList = new List<SharpMap.Layers.VectorLayer>();
        public static List<SharpMap.Layers.VectorLayer> innLayersList = new List<SharpMap.Layers.VectorLayer>();
        public static List<SharpMap.Layers.VectorLayer> transportationLayersList = new List<SharpMap.Layers.VectorLayer>();
        public static List<SharpMap.Layers.VectorLayer> culturalLayersList = new List<SharpMap.Layers.VectorLayer>();
        public static List<SharpMap.Layers.VectorLayer> touristActivityLayersList = new List<SharpMap.Layers.VectorLayer>();

        public static void initLayers(SharpMap.Map _sharpMap, List<string> types, List<SharpMap.Layers.VectorLayer> layersList,bool typeEnabled, string query)
        {
            foreach(var layer in layersList)
            {
                _sharpMap.Layers.Remove(layer);
            }
            layersList.RemoveAll(x => true);
            foreach(var name in types)
            {
                SharpMap.Layers.VectorLayer pointsLayer = new SharpMap.Layers.VectorLayer(name);

                var provajder = new SharpMap.Data.Providers.PostGIS(connString, "points", geomname, idname);
                provajder.DefinitionQuery = "type = '" + name+ "' " + query?? "";

                pointsLayer.Style.Symbol = Image.FromFile(Directory.GetCurrentDirectory().Replace('\\', '/') +"/pic/" + name + ".png");
                pointsLayer.Style.SymbolScale= 0.8f;
                pointsLayer.DataSource = provajder;
                //pointsLayer.LabelColumn = "name";
                ////pointsLayer.LabelFilter = FilterLabels;
                //pointsLayer.LabelStringDelegate = ChangeLabelName;
                //pointsLayer.Style.CollisionDetection = true;
                //pointsLayer.Style.CollisionBuffer = new SizeF(25, 25);
                //pointsLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
                //pointsLayer.Style.Font = new Font(FontFamily.Families.Where(x => x.Name == "Arial").FirstOrDefault(), 10 - ZoomRegulator.zoomRegulator.zoom_level * 0.7f, FontStyle.Italic);
                //pointsLayer.Style.ForeColor = Color.FromArgb(unchecked((int)0xff071e42));
                pointsLayer.Style.MaxVisible = ZoomRegulator.startZoom * ZoomRegulator.ZOOM_FACTOR * ZoomRegulator.ZOOM_FACTOR * ZoomRegulator.ZOOM_FACTOR;
                pointsLayer.Enabled = typeEnabled;

                var comp = _sharpMap.Zoom;
                layersList.Add(pointsLayer);
                _sharpMap.Layers.Add(pointsLayer);
            }
            
        }
        public static void init(SharpMap.Map _sharpMap,string query)
        {
            initLayers(_sharpMap, serviceTypes, serviceLayersList,serviceTypeEnabled, query);
            initLayers(_sharpMap, utilityTypes, utilityLayersList,utilityTypeEnabled, query);
            initLayers(_sharpMap, innTypes, innLayersList,innTypeEnabled, query);
            initLayers(_sharpMap, transportationTypes, transportationLayersList,transportationTypeEnabled, query);
            initLayers(_sharpMap, culturalTypes, culturalLayersList,culturalTypeEnabled, query);
            initLayers(_sharpMap, touristActivityTypes, touristActivityLayersList,touristActivityTypeEnabled, query);
        }
        public static void toggleServiceLayer(bool active)
        {
            serviceTypeEnabled = active;
            foreach(var layer in serviceLayersList)
            {
                layer.Style.Enabled = active;
            }
        }
        public static void toggleUtilityLayer(bool active)
        {
            utilityTypeEnabled = active;
            foreach (var layer in utilityLayersList)
            {
                layer.Style.Enabled = active;
            }
        }
        public static void toggleInnLayer(bool active)
        {
            innTypeEnabled = active;
            foreach (var layer in innLayersList)
            {
                layer.Style.Enabled = active;
            }
        }
        public static void toggleTransportationLayer(bool active)
        {
            transportationTypeEnabled = active;
            foreach (var layer in transportationLayersList)
            {
                layer.Style.Enabled = active;
            }
        }
        public static void toggleCulturalLayer(bool active)
        {
            culturalTypeEnabled = active;
            foreach (var layer in culturalLayersList)
            {
                layer.Style.Enabled = active;
            }
        }
        public static void toggleTouristLayer(bool active)
        {
            touristActivityTypeEnabled = active;
            foreach (var layer in touristActivityLayersList)
            {
                layer.Style.Enabled = active;
            }
        }
        public static void FilterLabels(List<SharpMap.Rendering.BaseLabel> list)
        {
            foreach (var label in list)
                label.Show = true;

            int i = 0;
            int j = 0;
            int count = list.Count();
            while (i < count - 1) 
            {
                var a = list[i].Box;

                while(j< count && list[i].Show)
                {
                    var b = list[j].Box;

                    if (!((Math.Abs((a.Right - a.Left) - (b.Right - b.Left)) * 2 < (a.Width + b.Width)) && (Math.Abs((a.Top - a.Bottom) - (b.Top - b.Bottom)) * 2 < (a.Height + b.Height))))
                        list[i].Show = false;
                    ++j;
                }
                ++i;
            }

        }
        public static string ChangeLabelName(SharpMap.Data.FeatureDataRow target)
        {
            var name = target["name"].ToString();
            if (name.Length > 10)
                name = name.Substring(0, 10);

            return name;
        }

       
}
}
