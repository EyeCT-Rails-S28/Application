using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class TramTest
    {
        private Tram _tram;

        [TestInitialize]
        public void TramInit()
        {
            _tram = new Tram(1, TramType.Combino, Status.Remise, new Line(1), false);
        }

        [TestMethod]
        public void TramConstructorTest()
        {
            Assert.AreEqual(1, _tram.Id);
            Assert.AreEqual(Status.Remise, _tram.Status);
            Assert.AreEqual(false, _tram.HasForcedLine);
        }

        [TestMethod]
        public void TramToStringTest()
        {
            Assert.AreEqual("1 - Remise", _tram.ToString());
        }
    }
}
