using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class DepotTest
    {
        private Depot _depot;

        [TestInitialize]
        public void DepotInit()
        {
            _depot = new Depot(1, "Havenstraat");
        }

        [TestMethod]
        public void DepotConstructorTest()
        {
            Assert.AreEqual(1, _depot.Id);
            Assert.AreEqual("Havenstraat", _depot.Name);
        }

        [TestMethod]
        public void DepotAddTrackTest()
        {
            _depot.AddTrack(new Track(3));

            Assert.AreEqual(1, _depot.Tracks.Count);
            Assert.AreEqual(3, _depot.Tracks[0].Id);
        }

        [TestMethod]
        public void DepotPropertyTest()
        {
            _depot.AddTrack(new Track(42));

            Assert.AreEqual(1, _depot.Tracks.Count, "Pre Clear");
            _depot.Tracks.Clear();
            Assert.AreEqual(1, _depot.Tracks.Count, "After Clear");
        }

        [TestMethod]
        public void DepotToStringTest()
        {
            Assert.AreEqual("Havenstraat", _depot.ToString());
        }
    }
}
