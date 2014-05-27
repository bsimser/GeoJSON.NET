namespace BilSimser.GeoJson.GeoJson
{
    public class Feature
    {
        public Feature()
        {
            geometry = new Geometry();
            properties = new Properties();
        }

        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
}