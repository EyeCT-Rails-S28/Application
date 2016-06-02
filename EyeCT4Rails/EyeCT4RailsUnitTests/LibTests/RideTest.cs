using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class RideTest
    {
        private Ride _ride;

        [TestInitialize]
        public void RideInit()
        {
            _ride = new Ride(1, new Line(1), new User(1, "Piet", "", new Function(Role.Driver, new List<Right> {Right.ManageRide})), new Tram(1, TramType.Combino,  Status.Dienst, new Line(1), false));
        }

        [TestMethod]
        public void RideConstructorTest()
        {
            Assert.AreEqual(1, _ride.Id);
            Assert.AreEqual(Role.Driver, _ride.User.Function.Role);
            Assert.AreEqual("Piet", _ride.User.Name);
            Assert.IsNotNull(_ride.Tram);
        }

        [TestMethod]
        public void RideToStringTest()
        {
            Assert.AreEqual("1 - Line: 1 - Tram: 1 - Driver: Piet", _ride.ToString());
        }
    }
}
