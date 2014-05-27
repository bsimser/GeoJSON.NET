using System.Linq;
using System.Xml;
using BilSimser.GeoJson.GeoJson;
using NUnit.Framework;

namespace BilSimser.GeoJson.Tests
{
    [TestFixture]
    public class MinimalTests
    {
        private XmlDocument _sut;
        private const string FileName = "borabora.kml";

        [SetUp]
        public void SetUp()
        {
            TestServices.CreateFileFromResource("BilSimser.GeoJson.Tests.Data." + FileName, FileName);
            var input = TestServices.ReadFile(FileName);
            _sut = new XmlDocument();
            _sut.LoadXml(input);
        }

        [Test]
        public void LoadHasOneFeature()
        {
            var result = new GeoJsonRootObject();

            var fc = result.ToFeatureCollection(_sut);

            Assert.AreEqual(fc.features.Count, 1);
        }

        [Test]
        public void CanGetNameProperty()
        {
            var result = new GeoJsonRootObject();

            var fc = result.ToFeatureCollection(_sut);

            Assert.AreEqual("Bora-Bora Airport", fc.features[0].properties.values.First(x => x.Key == "name").Value);
        }

        [Test]
        public void DescriptionShouldBeNull()
        {
            var result = new GeoJsonRootObject();

            var fc = result.ToFeatureCollection(_sut);

            Assert.AreEqual(fc.features[0].properties.values.Count(x => x.Key == "description"), 0);
        }

        [TearDown]
        public void TearDown()
        {
            TestServices.DeleteFile(FileName);
        }
    }
}