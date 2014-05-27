using System.Collections.Generic;

namespace BilSimser.GeoJson.Kml
{
    public class Folder
    {
        public string name { get; set; }
        public List<Placemark> Placemark { get; set; }
    }
}