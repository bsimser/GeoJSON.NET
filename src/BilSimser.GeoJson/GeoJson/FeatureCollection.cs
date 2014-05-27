using System.Collections.Generic;

namespace BilSimser.GeoJson.GeoJson
{
    public class FeatureCollection
    {
        public FeatureCollection()
        {
            type = "FeatureCollection";
            features = new List<Feature>();
        }

        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}