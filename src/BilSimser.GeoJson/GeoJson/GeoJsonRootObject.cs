using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using BilSimser.GeoJson.JsonConverters;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace BilSimser.GeoJson.GeoJson
{
    public class GeoJsonRootObject
    {
        private readonly string[] _geotypes = {"Polygon", "LineString", "Point", "Track"};

        public string ConvertFrom(XmlDocument doc)
        {
            var fc = ToFeatureCollection(doc);
            
            return JsonConvert.SerializeObject(fc, Formatting.Indented, new JsonConverter[]
            {
                new PositionConverter(typeof (Position)),
                new LineStringConverter(typeof (LineString)),
                new PropertiesConverter(typeof (Properties))
            });
        }

        public FeatureCollection ToFeatureCollection(XmlDocument doc)
        {
            var fc = new FeatureCollection();

            // TODO
            // styleindex keeps track of hashed styles in order to match features
            // styleIndex = {};

            // all root placemarks in the file
            var placemarks = Get(doc.DocumentElement, "Placemark");

            // TODO
            // get all styles

            // TODO
            // for each style
            // create a hash in styleindex

            foreach (XmlElement node in placemarks)
            {
                fc.features.Add(GetPlacemark(node));
            }
            
            return fc;
        }

        private Feature GetPlacemark(XmlElement root)
        {
            var geoms = GetGeometry(root);
            var properties = new List<KeyValuePair<string, object>>();
            var extendedData = GetOne(root, "ExtendedData");
            if (geoms.Count == 0) return new Feature();

            var name = NodeVal(GetOne(root, "name"));
            if (name != null)
            {
                properties.Add(new KeyValuePair<string, object>("name", name));
            }

            var description = NodeVal(GetOne(root, "description"));
            if (description != null)
            {
                properties.Add(new KeyValuePair<string, object>("description", description));
            }

            // TODO
            // if timeSpan

            // TODO
            // if lineStyle

            // TODO
            // if polyStyle

            if (extendedData != null)
            {
                var datas = Get(extendedData, "Data");
                var simpleDatas = Get(extendedData, "SimpleData");
                for (var i = 0; i < datas.Count; i++)
                {
                    var xmlAttributeCollection = datas[i].Attributes;
                    if (xmlAttributeCollection != null)
                    {
                        properties.Add(new KeyValuePair<string, object>(
                            xmlAttributeCollection["name"].Value,
                            NodeVal(GetOne((XmlElement) datas[i], "value"))));
                    }
                }
                for (var i = 0; i < simpleDatas.Count; i++)
                {
                    var xmlAttributeCollection = simpleDatas[i].Attributes;
                    if (xmlAttributeCollection != null)
                    {
                        properties.Add(new KeyValuePair<string, object>(
                            xmlAttributeCollection["name"].Value,
                            NodeVal(simpleDatas[i])));
                    }
                }
            }

            return new Feature
            {
                type = "Feature",
                geometry = (geoms.Count == 1)
                    ? geoms[0]
                    : new Geometry
                    {
                        type = "GeometryCollection"
                    },
                properties = new Properties
                {
                    values = properties
                }
            };
        }

        private List<Geometry> GetGeometry(XmlElement root)
        {
            while (true)
            {
                var geoms = new List<Geometry>();

                if (GetOne(root, "MultiGeometry") != null)
                {
                    root = GetOne(root, "MultiGeometry");
                    continue;
                }

                if (GetOne(root, "MultiTrack") != null)
                {
                    root = GetOne(root, "MultiTrack");
                    continue;
                }

                foreach (var geoType in _geotypes)
                {
                    var geomNodes = Get(root, geoType);
                    if (geomNodes == null) continue;

                    foreach (XmlElement geomNode in geomNodes)
                    {
                        switch (geoType)
                        {
                            case "Point":
                                // TODO add support for PointGeometry
                                // Postion
                                geoms.Add(new Geometry
                                {
                                    type = geoType
                                });
                                break;

                            case "LineString":
                                // TODO 
                                var lines = Get(geomNode, "coordinates");
                                var lspos = new List<Position>();
                                for (var i = 0; i < lines.Count; i++)
                                {
                                    var c = NodeVal(lines[i]);
                                    lspos.Add(new Position());
                                }
                                //var pos = NodeVal(lines);
                                geoms.Add(new LineStringGeometry
                                {
                                    type = geoType,
                                    coordinates = lspos
                                });
                                break;

                            case "Polygon":
                                geoms.Add(GetPolygonGeometry(geomNode, geoType));
                                break;

                            case "Track":
                                // TODO add support for TrackGeometry
                                geoms.Add(new Geometry
                                {
                                    type = geoType
                                });
                                break;
                        }
                    }
                }

                return geoms;
            }
        }

        private static PolygonGeometry GetPolygonGeometry(XmlElement geomNode, string geoType)
        {
            var rings = Get(geomNode, "LinearRing");
            var coords = new List<LinearRing>();
            for (var j = 0; j < rings.Count; j++)
            {
                var linearRing = ToLinearRing(NodeVal(GetOne((XmlElement) rings[j], "coordinates")));
                coords.Add(linearRing);
            }
            return new PolygonGeometry
            {
                type = geoType,
                // TODO add support for multiple rings (polygons with holes)
                // TODO this only selects the coordinates for the first polygon
                coordinates = coords[0].coordinates
            };
        }

        private static LinearRing ToLinearRing(string v)
        {
            const string trimSpace = @"(/^\s*|\s*$/g)";
            const string splitSpace = @"(/\s+/)";
            v = Regex.Replace(v, "\n", "");
            v = Regex.Replace(v, @"[ ]{2,}", " ");
            var coords = Regex.Split(v.Trim().Replace(trimSpace, ""), splitSpace);
            var linestrings = coords.Select(ToLineString).ToList();
            return new LinearRing
            {
                coordinates = linestrings
            };
        }

        private static LineString ToLineString(string v)
        {
            var coords = v.Trim().Split(new[] {' '});
            var positions = (from tuple in coords
                select tuple.Split(new[] {','})
                into split
                select NumArray(split)
                into item
                select new Position
                {
                    x = item[0],
                    y = item[1],
                    z = item[2]
                }).ToList();
            return new LineString
            {
                coordinates = positions
            };
        }

        private static List<float> NumArray(IEnumerable<string> x)
        {
            return x.Select(float.Parse).ToList();
        }

        private static string NodeVal(XmlNode xmlElement)
        {
            if (xmlElement != null)
            {
                xmlElement.Normalize();
            }
            return (xmlElement != null && xmlElement.FirstChild != null && xmlElement.FirstChild.Value != null)
                ? xmlElement.FirstChild.Value
                : null;
        }

        private static XmlElement GetOne(XmlElement item, string tagname)
        {
            var n = Get(item, tagname);
            return (XmlElement) (n.Count > 0 ? n[0] : null);
        }

        private static XmlNodeList Get(XmlElement doc, string tagname)
        {
            return doc.GetElementsByTagName(tagname);
        }
    }
}