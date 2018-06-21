using GeoAPI.CoordinateSystems;
using ProjNet.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG.Helpers
{
    public class CoordinateSystem
    {
        public static IProjectedCoordinateSystem CreateUtmProjection(int utmZone)
        {
            CoordinateSystemFactory cFac = new CoordinateSystemFactory();
            IEllipsoid ellipsoid = cFac.CreateFlattenedSphere("WGS 84", 6378137, 298.257223563, LinearUnit.Metre);
            IHorizontalDatum datum = cFac.CreateHorizontalDatum("WGS_1984", DatumType.HD_Geocentric, ellipsoid, null);
            IGeographicCoordinateSystem gcs = cFac.CreateGeographicCoordinateSystem("WGS 84", AngularUnit.Degrees, datum, PrimeMeridian.Greenwich,
                new AxisInfo("Lon", AxisOrientationEnum.East), new AxisInfo("Lat", AxisOrientationEnum.North));
            List<ProjectionParameter> parameters = new List<ProjectionParameter>();
            parameters.Add(new ProjectionParameter("latitude_of_origin", 0));
            parameters.Add(new ProjectionParameter("central_meridian", -183 + 6 * utmZone));
            parameters.Add(new ProjectionParameter("scale_factor", 0.9996));
            parameters.Add(new ProjectionParameter("false_easting", 7500000));
            parameters.Add(new ProjectionParameter("false_northing", 0.0));
            IProjection projection = cFac.CreateProjection("Transverse Mercator", "Transverse_Mercator", parameters);

            return cFac.CreateProjectedCoordinateSystem("WGS 84 / UTM zone " + utmZone.ToString() + "N", gcs, 
                projection, LinearUnit.Metre, new AxisInfo("East", AxisOrientationEnum.East), 
                new AxisInfo("North", AxisOrientationEnum.North));
        }
    }
}
