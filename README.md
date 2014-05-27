# GeoJSON.NET

## Convert KML to GeoJSON

GeoJson.NET is a library to convert [KML](https://developers.google.com/kml/documentation/) files into [GeoJSON](http://www.geojson.org/) format for .NET. 

GeoJSON is a format for encoding a variety of geographic data structures. For more detail about the GeoJSON format please see the [full specification](http://geojson.org/geojson-spec.html).

This project is based on the JavaScript project [toGeoJSON](http://mapbox.github.io/togeojson/).

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
* ExtendedData
* SimpleData

In Progress:

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
