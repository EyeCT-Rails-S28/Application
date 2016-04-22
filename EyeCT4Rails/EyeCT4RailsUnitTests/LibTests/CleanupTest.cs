using System;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class CleanupTest
    {
        private Cleanup _cleanup;

        [TestInitialize]
        public void CleanupInit()
        {
            _cleanup = new Cleanup(1, DateTime.Today, false, JobSize.Big, new Tram(1, Status.Schoonmaak, new Line(1), false), new User(1, "Piet", "", Role.Cleanup));
        }

        [TestMethod]
        public void CleanupConstructorTest()
        {
            Assert.AreEqual(1,_cleanup.Id);
            Assert.AreEqual(DateTime.Today, _cleanup.Date);
            Assert.IsNotNull(_cleanup.User);
            Assert.IsNotNull(_cleanup.Tram);
        }

        [TestMethod]
        public void CleanupToStringTest()
        {
            string date = DateTime.Today.ToString();
            Assert.AreEqual("CL: " + date + " - Not Done - Size: Big - Tram: 1 - User: Piet", _cleanup.ToString());
        }
    }
}
