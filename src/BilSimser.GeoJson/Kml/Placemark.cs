namespace BilSimser.GeoJson.Kml
{
    public class Placemark
    {
        public string name { get; set; }
        public string styleUrl { get; set; }
        public ExtendedData ExtendedData { get; set; }
        public Polygon Polygon { get; set; }
    }
}