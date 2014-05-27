using System.Collections.Generic;

namespace BilSimser.GeoJson.Kml
{
    public class Schema
    {
        public string name { get; set; }
        public string id { get; set; }
        public List<SimpleField> SimpleField { get; set; }
    }
}