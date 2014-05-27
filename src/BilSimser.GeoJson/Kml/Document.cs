using System.Collections.Generic;

namespace BilSimser.GeoJson.Kml
{
    public class Document
    {
        public string name { get; set; }
        public string open { get; set; }
        public List<Style> Style { get; set; }
        public List<Schema> Schema { get; set; }
        public List<Folder> Folder { get; set; }
    }
}