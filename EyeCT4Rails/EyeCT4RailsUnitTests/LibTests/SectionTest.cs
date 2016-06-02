using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class SectionTest
    {
        private Section _section1;
        private Section _section2;

        [TestInitialize]
        public void SectionInit()
        {
            _section1 = new Section(1, false);
            _section2 = new Section(2, true, new Tram(1, TramType.Combino,  Status.Remise, new Line(1), false));
        }

        [TestMethod]
        public void SectionConstructorTest()
        {
            Assert.AreEqual(1, _section1.Id);
            Assert.AreEqual(true, _section2.Blocked);
            Assert.AreEqual(Status.Remise, _section2.Tram.Status);
        }

        [TestMethod]
        public void SectionToStringTest()
        {
            Assert.AreEqual("1 - Not Blocked - No Tram", _section1.ToString());
            Assert.AreEqual("2 - Blocked - 1", _section2.ToString());
        }
    }
}
