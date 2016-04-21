using System.Linq;
using EyeCT4RailsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class TrackTest
    {
        private Track _track;

        [TestInitialize]
        public void TrackInit()
        {
            _track = new Track(1);
        }

        [TestMethod]
        public void TrackConstructorTest()
        {
            Assert.AreEqual(1, _track.Id);
        }

        [TestMethod]
        public void TrackAddSectionTest()
        {
            _track.AddSection(new Section(1, false));
            _track.AddSection(new Section(2, true));

            Assert.AreEqual(2, _track.Sections.Count);
            Assert.AreEqual(1, _track.Sections.First().Id);
        }

        [TestMethod]
        public void TrackToStringTest()
        {
            _track.AddSection(new Section(1, false));
            _track.AddSection(new Section(2, true));

            Assert.AreEqual("1 - Length: 2", _track.ToString());
        }
    }
}
