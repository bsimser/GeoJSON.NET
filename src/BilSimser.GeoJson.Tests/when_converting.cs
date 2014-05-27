using System.IO;
using System.Xml;
using NUnit.Framework;

namespace BilSimser.GeoJson.Tests
{
    [TestFixture]
    public class when_converting
    {
        [Test]
        public void minimal_kml_result_is_not_blank()
        {
            const string fileName = "borabora.kml";
            var path = Path.Combine(Path.GetTempPath(), fileName);
            TestServices.CreateTextFile("BilSimser.GeoJson.Tests.Data.borabora.kml", fileName);

            var input = TestServices.ReadFile(fileName);
            var result = GeoJsonConvert.Convert(input);

            Assert.IsNotEmpty(result);

            TestServices.DeleteFile(fileName);
        }

        [Test]
        public void blank_document_throws_xml_exception()
        {
            Assert.Throws<XmlException>(() => GeoJsonConvert.Convert(string.Empty));
        }

        [Test]
        public void partial_document_throws_xml_exception()
        {
            Assert.Throws<XmlException>(delegate
            {
                const string partial = "<kml><Placemark><name>Bora-Bora Airport</name></Point></Placemark></kml>";
                GeoJsonConvert.Convert(partial);
            });
        }

        [Test]
        public void invalid_xml_throws_xml_exception()
        {
            Assert.Throws<XmlException>(delegate
            {
                const string partial = "<kml><Placemark>";
                GeoJsonConvert.Convert(partial);
            });
        }
    }
}
