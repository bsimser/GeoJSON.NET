using System.Collections.Generic;

namespace BilSimser.GeoJson.GeoJson
{
    public class PolygonGeometry : Geometry
    {
        public PolygonGeometry()
        {
            coordinates = new List<LineString>();
        }

        public List<LineString> coordinates { get; set; }
    }
}