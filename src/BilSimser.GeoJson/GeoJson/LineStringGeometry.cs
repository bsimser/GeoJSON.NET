using System.Collections.Generic;

namespace BilSimser.GeoJson.GeoJson
{
    public class LineStringGeometry : Geometry
    {
        public LineStringGeometry()
        {
            coordinates = new List<Position>();
        }

        public List<Position> coordinates { get; set; }
    }
}