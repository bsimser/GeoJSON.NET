# GeoJSON.NET

## Convert KML to GeoJSON

GeoJson.NET is a library to convert [KML](https://developers.google.com/kml/documentation/) files into [GeoJSON](http://www.geojson.org/) format for .NET. 

GeoJSON is a format for encoding a variety of geographic data structures. The GeoJSON format is based on JavaScript Object Notation (JSON). For more detail about the GeoJSON format please see the [full specification](http://geojson.org/geojson-spec.html).

This .NET project is based on the JavaScript project [toGeoJSON](http://mapbox.github.io/togeojson/).

## API

### `GeoJsonConvert.Convert(xml)`

Convert a KML document to GeoJSON. The first argument, `xml`, must be an XmlDocument
document.

The output is a string of GeoJSON data.

### `GeoJsonConvert.Convert(kml)`

Convert a KML document to GeoJSON. The first argument, `kml`, must be a System.String representation of a KML document.

The output is a string of GeoJSON data.

## KML

Supported:

* Polygon
* name & description
* ExtendedData
* SimpleData

In Progress:

* Point
* LineString
* MultiGeometry -> GeometryCollection
* Styles with hashing
* Tracks & MultiTracks with `gx:coords`, including altitude
* [TimeSpan](https://developers.google.com/kml/documentation/kmlreference#timespan)

Not supported yet:

* Various silly Google extensions (will never be supported)
* NetworkLinks
* GroundOverlays

## GeoJSON (and JSON) Resources

* [The GeoJSON Format Specification](http://geojson.org/geojson-spec.html)
* [toGeoJSON Online Converter](http://mapbox.github.io/togeojson/)
* [GeoJSON Validator](http://geojsonlint.com/)
* [Another GeoJSON Validator](https://github.com/mapbox/geojsonhint)
* [GeoJSON Discussion List](http://lists.geojson.org/listinfo.cgi/geojson-geojson.org)
* [Bing Maps V7 GeoJSON Module](http://bingmapsv7modules.codeplex.com/wikipage?title=GeoJSON%20Module)
* [JSON Editor Online](http://www.jsoneditoronline.org/)
* [James Newton-Kings' Json.NET Library](http://james.newtonking.com/json)
* [JSON Schema for describing your JSON data format](http://json-schema.org/)
