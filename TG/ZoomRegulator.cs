using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG
{
    public class ZoomRegulator
    {
        private const float ZOOM_FACTOR = 0.35f;

        public int zoom_level = 1;
        public bool showBuilding = false;
        public bool showRailways = false;
        public bool showPoints = false;

        private static ZoomRegulator _zoomRegulator = null;
        private ZoomRegulator() { }
        public static ZoomRegulator zoomRegulator
        {
            get
            {
                if(_zoomRegulator == null)
                {
                    _zoomRegulator = new ZoomRegulator();
                }
                return _zoomRegulator;
            }
        }

        public Image ZoomIn()
        {
            if (zoom_level == 2)
            {
                showBuilding = true;
                Layers.layers.toggleBuildings(true);
            }
            if (zoom_level == 4)
            {
                showPoints = true;
                Layers.layers.togglePoints(true);
            }
            if (zoom_level < 6)
            {
                zoom_level += 1;
                Layers.layers.changeZoom(ZOOM_FACTOR);
            }

            return Layers.layers.getMap();
        }
        public Image ZoomOut()
        {
            if (zoom_level == 3)
            {
                showBuilding = false;
                Layers.layers.toggleBuildings(false);
            }
            if (zoom_level == 5)
            {
                showPoints = false;
                Layers.layers.togglePoints(false);
            }
            if (zoom_level > 1)
            {
                zoom_level--;
                Layers.layers.changeZoom(1 / ZOOM_FACTOR);
            }

            return Layers.layers.getMap();
        }

    }
}
