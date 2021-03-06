﻿using System;
using System.Collections.Generic;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class MaintenanceTest
    {
        private Job _maintenance;

        [TestInitialize]
        public void MaintenanceInit()
        {
            _maintenance = new Job(1, DateTime.Today, false, JobType.Maintenance, JobSize.Big,
                new Tram(1, TramType.Combino, Status.Schoonmaak, new Line(1), false),
                new User(1, "Piet", "", new Function(Role.Mechanic, new List<Right> {Right.ManageRepair})));
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
