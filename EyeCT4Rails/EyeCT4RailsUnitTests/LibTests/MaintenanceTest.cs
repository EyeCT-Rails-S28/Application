using System;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class MaintenanceTest
    {
        private MaintenanceJob _maintenance;

        [TestInitialize]
        public void MaintenanceInit()
        {
            _maintenance = new MaintenanceJob(1, DateTime.Today, false, JobSize.Big, new Tram(1, Status.Schoonmaak, new Line(1), false), new User(1, "Piet", "", Privilege.Mechanic));
        }

        [TestMethod]
        public void MaintenanceConstructorTest()
        {
            Assert.AreEqual(1, _maintenance.Id);
            Assert.AreEqual(DateTime.Today, _maintenance.Date);
            Assert.IsNotNull(_maintenance.User);
            Assert.IsNotNull(_maintenance.Tram);
        }

        [TestMethod]
        public void MaintenanceToStringTest()
        {
            string date = DateTime.Today.ToString();
            Assert.AreEqual("MT: " + date + " - Not Done - Size: Big - Tram: 1 - User: Piet", _maintenance.ToString());
        }
    }
}
