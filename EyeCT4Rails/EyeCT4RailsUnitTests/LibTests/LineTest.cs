using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class LineTest
    {
        private Line _line;

        [TestInitialize]
        public void LineInit()
        {
            _line = new Line(1);
        }

        [TestMethod]
        public void LineConstructorTest()
        {
            Assert.AreEqual(1, _line.Id);
            Assert.IsNull(_line.AssociatedLine);
        }

        [TestMethod]
        public void LineToStringTest()
        {
            Assert.AreEqual("1", _line.ToString());
        }
    }
}
