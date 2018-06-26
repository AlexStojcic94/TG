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

        public static List<String> allTypes = new List<string>(new string[] { "police", "hospital", "doctors", "bank", "post_office", "pharmacy", "embassy", "toilets", "drinking_water", "camp_site", "hostel", "hotel", "museum", "grave_yard", "archaeological_s", "memorial", "castle", "monument", "artwork", "arts_centre", "battlefield", "ruins", "place_of_worship", "picnic_site", "viewpoint", "nightclub", "theatre", "cafe", "swimming_pool" });
        public static List<String> serviceTypes = new List<string>(new string[] { "police", "hospital", "doctors", "bank", "post_office", "pharmacy", "embassy" });
        public static List<String> utilityTypes = new List<string>(new string[] { "toilets", "drinking_water" });
        public static List<String> innTypes = new List<string>(new string[] { "camp_site", "hostel", "hotel"});
        public static List<String> transportationTypes = new List<string>(new string[] {"bus_stop", "parking", "bus_station", "taxi" });
        public static List<String> culturalTypes = new List<string>(new string[] { "museum","grave_yard", "archaeological_s", "memorial", "castle", "monument", "artwork", "arts_centre", "battlefield", "ruins", "place_of_worship" });
        public static List<String> touristActivityTypes = new List<string>(new string[] { "picnic_site", "viewpoint", "nightclub", "theatre", "cafe", "swimming_pool" });

        public static SharpMap.Layers.VectorLayer searchLayer;
        public static List<String> allElementsOfType;

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

        public static List<string> getNames()
        {
            string queryString1 = "select name from points where type in ('";
            List<string> list = new List<string>();
            string delimiter = "', '";


            queryString1 += serviceTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            queryString1 += utilityTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            queryString1 += innTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            queryString1 += transportationTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            queryString1 += culturalTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            queryString1 += touristActivityTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;


            queryString1 = queryString1.Remove(queryString1.Length - delimiter.Length - 1, delimiter.Length) + ")";
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
            
            list = list.Concat(allTypes).ToList();

            return list;
        }

        public static SharpMap.Layers.VectorLayer search(string name)
        {
            searchLayer = new SharpMap.Layers.VectorLayer("search");
            
            string query = "and type in ('";

            string delimiter = "', '";

            query += serviceTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += utilityTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += innTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += transportationTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += culturalTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += touristActivityTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query = query.Remove(query.Length - delimiter.Length - 1, delimiter.Length) + ")";
            var provajder = new SharpMap.Data.Providers.PostGIS(connString, "points", geomname, idname);

            var fullQuery = "name in ('" + name + "', '" + LaToCy.CyToLaConverter.Translit(name) + "') " + query ?? "";
            if (allTypes.Contains(LaToCy.CyToLaConverter.Translit(name)))
                fullQuery = " type = '" + LaToCy.CyToLaConverter.Translit(name) + "' and name != '' and name is not null";
            provajder.DefinitionQuery = fullQuery;

            searchLayer.Style.Symbol = Image.FromFile(Directory.GetCurrentDirectory().Replace('\\', '/') + "/pic/pin.png");
            searchLayer.Style.SymbolScale = 0.3f;
            searchLayer.DataSource = provajder;
            //searchLayer.Style.MaxVisible = ZoomRegulator.startZoom * ZoomRegulator.ZOOM_FACTOR * ZoomRegulator.ZOOM_FACTOR * ZoomRegulator.ZOOM_FACTOR;
            searchLayer.Enabled = true;



            return searchLayer;
        }
        public static void findAllElementsOfType(string type)
        {
            allElementsOfType = new List<string>();
            string query = "select gid from points where type = '" + type + "' and name != '' and name is not null";

            using (var connection = new NpgsqlConnection(connString))
            {

                connection.Open();

                var command = new NpgsqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allElementsOfType.Add(LaToCy.CyToLaConverter.Translit(reader[0].ToString().Replace("'","''")));
                    }
                }

                connection.Close();
            }

        }
        public static string formDistanceQuery(string name, float _distance)
        {
            if (allTypes.Contains(LaToCy.CyToLaConverter.Translit(name)))
            {
                findAllElementsOfType(LaToCy.CyToLaConverter.Translit(name));
            }
            else
            {
                allElementsOfType = new List<string>();
                allElementsOfType.Add(name);
            }
            string query = "and type in ('";

            string delimiter = "', '";

            query += serviceTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += utilityTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += innTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += transportationTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += culturalTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query += touristActivityTypes.Aggregate((i, j) => i + delimiter + j) + delimiter;

            query = query.Remove(query.Length - delimiter.Length - 1, delimiter.Length) + ")";

            string returnString = " and ( ";
            foreach (var uniqueName in allElementsOfType)
            {
                string namePart = "name in ('" + uniqueName + "', '" + LaToCy.CyToLaConverter.Translit(uniqueName) + "') ";
                if (allTypes.Contains(LaToCy.CyToLaConverter.Translit(name)))
                    namePart = "gid =" + uniqueName + " ";
                returnString += " ST_DWithin(geom, (select geom from points where " + namePart +
                query + " limit 1)" + " ," + _distance + ")" + " or ";
            }
            returnString = returnString.Remove(returnString.Length - 4, 3);
            returnString += ") ";

            return returnString;
        }
        public static List<string> queryPoints(string query)
        {
            var returnList = new List<string>();
            string fullQuery = "select name, type, gid from points ";
            if (query!= "")
                fullQuery = "select name, type, gid from points where " + query.Remove(0,4);

            using (var connection = new NpgsqlConnection(connString))
            {

                connection.Open();

                var command = new NpgsqlCommand(fullQuery, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (serviceTypes.Contains(reader[1].ToString()) && serviceTypeEnabled)
                            returnList.Add(LaToCy.CyToLaConverter.Translit(((reader[0].ToString() != "") ? reader[0].ToString() : "unkown") + " - " + reader[1].ToString() + " - "+ reader[2].ToString()));
                        if (utilityTypes.Contains(reader[1].ToString()) && utilityTypeEnabled)
                            returnList.Add(LaToCy.CyToLaConverter.Translit(((reader[0].ToString() != "") ? reader[0].ToString() : "unkown") + " - " + reader[1].ToString() + " - " + reader[2].ToString()));
                        if (innTypes.Contains(reader[1].ToString()) && innTypeEnabled)
                            returnList.Add(LaToCy.CyToLaConverter.Translit(((reader[0].ToString() != "") ? reader[0].ToString() : "unkown") + " - " + reader[1].ToString() + " - " + reader[2].ToString()));
                        if (transportationTypes.Contains(reader[1].ToString()) && transportationTypeEnabled)
                            returnList.Add(LaToCy.CyToLaConverter.Translit(((reader[0].ToString() != "") ? reader[0].ToString() : "unkown") + " - " + reader[1].ToString() + " - " + reader[2].ToString()));
                        if (culturalTypes.Contains(reader[1].ToString()) && culturalTypeEnabled)
                            returnList.Add(LaToCy.CyToLaConverter.Translit(((reader[0].ToString() != "") ? reader[0].ToString() : "unkown") + " - " + reader[1].ToString() + " - " + reader[2].ToString()));
                        if (touristActivityTypes.Contains(reader[1].ToString()) && touristActivityTypeEnabled)
                            returnList.Add(LaToCy.CyToLaConverter.Translit(((reader[0].ToString() != "") ? reader[0].ToString() : "unkown") + " - " + reader[1].ToString() + " - " + reader[2].ToString()));
                    }
                }

                connection.Close();
            }

            return returnList;
        }
        public static string getLabelInfo(string from, string to)
        {
            string returnString = "";
            if (!allTypes.Contains(LaToCy.LaToCyConverter.Translit(from)))
            {
                string query = "select ST_Distance((select geom from points where gid = '" + to + "' limit 1), (select geom from points " +
                    "where name in ('" + from + "','" + LaToCy.LaToCyConverter.Translit(from) + "') limit 1))";

                using (var connection = new NpgsqlConnection(connString))
                {

                    connection.Open();

                    var command = new NpgsqlCommand(query, connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnString = reader[0].ToString();
                        }
                    }
                    connection.Close();
                }
                
            }
            return returnString;
        }

    }
}
