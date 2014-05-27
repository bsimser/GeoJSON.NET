# GeoJSON.NET

## Convert KML to GeoJSON

GeoJson.NET is a library to convert [KML](https://developers.google.com/kml/documentation/) files into [GeoJSON](http://www.geojson.org/) format for .NET

It is based on the JavaScript project [toGeoJSON](http://mapbox.github.io/togeojson/)

## API

### `Converter.Convert(xml)`

Convert a KML document to GeoJSON. The first argument, `xml`, must be an XmlDocument
document.

The output is a string of GeoJSON data.

### `Converter.Convert(input)`

Convert a KML document to GeoJSON. The first argument, `input`, must be a System.String representation of a KML document.

The output is a string of GeoJSON data.

## KML

Supported:

* Point
* Polygon
* LineString
* name & description
* ExtendedData
* SimpleData
* MultiGeometry -> GeometryCollection
* Styles with hashing
* Tracks & MultiTracks with `gx:coords`, including altitude
* [TimeSpan](https://developers.google.com/kml/documentation/kmlreference#timespan)

Not supported yet:

* Various silly Google extensions (will never be supported)
* NetworkLinks
* GroundOverlays

## FAQ
