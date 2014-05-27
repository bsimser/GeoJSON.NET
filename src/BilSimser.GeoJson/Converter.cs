using System;
using System.Xml;
using BilSimser.GeoJson.GeoJson;

namespace BilSimser.GeoJson
{
    /// <summary>
    /// Conversion class that will create GeoJSON output that
    /// can be validated by POSTing string to http://geojsonlint.com/validate.
    /// The converter is basically a C# port of https://github.com/mapbox/togeojson
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Converts a KML formatted string into a GeoJSON output
        /// </summary>
        /// <param name="input">The string represenation from a KML file</param>
        /// <returns>The contents of the KML file formatted to GeoJSON 1.0 format</returns>
        public string Convert(string input)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(input);
                return DoConvert(doc);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Converts an XmlDocument in KLM form into a GeoJSON output
        /// </summary>
        /// <param name="doc">The XmlDocument represenatition from a KML file</param>
        /// <returns>The contents of the KML file formatted to GeoJSON 1.0 format</returns>
        public string Convert(XmlDocument doc)
        {
            try
            {
                return DoConvert(doc);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static string DoConvert(XmlDocument doc)
        {
            var gj = new GeoJsonRootObject();
            var output = gj.ConvertFrom(doc);
            return output;
        }
    }
}
