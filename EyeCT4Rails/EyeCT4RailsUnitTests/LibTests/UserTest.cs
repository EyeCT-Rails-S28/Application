﻿using System.Collections.Generic;
using System.Linq;
using EyeCT4RailsLib;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LibTests
{
    [TestClass]
    public class UserTest
    {
        private User _user1;
        private User _user2;

        [TestInitialize]
        public void UserInit()
        {
            _user1 = new User(1, "Henk Stenk", "HenkyBaas@gmail.com", new Function(Role.Administrator, new List<Right> {Right.ManageUser,Right.ManageDepot,Right.ManageCleanup,Right.ManageRepair,Right.ManageRide}));
            _user2 = new User(2, "Piet Piraat", "Arrrr@gmail.com", new Function(Role.Mechanic, new List<Right> {Right.ManageRepair}));
        }

        [TestMethod]
        public void UserConstructorTest()
        {
            Assert.AreEqual(1, _user1.Id);
            Assert.AreEqual(Role.Administrator, _user1.Function.Role);
            Assert.AreEqual("Piet Piraat", _user2.Name);
        }

        [TestMethod]
        public void HasRightTest()
        {
            var enums = new List<Right> {
                Right.ManageCleanup, Right.ManageDepot, Right.ManageRepair, Right.ManageRide, Right.ManageUser
            };
            
            enums.ForEach(x => Assert.IsTrue(_user1.HasRight(x)));
            enums.FindAll(x => x != Right.ManageRepair).ToList().ForEach(y => Assert.IsFalse(_user2.HasRight(y)));
            Assert.IsTrue(_user2.HasRight(Right.ManageRepair));
        }

        [TestMethod]
        public void UserToStringTest()
        {
            Assert.AreEqual("1 - Henk Stenk - Administrator", _user1.ToString());
            Assert.AreEqual("2 - Piet Piraat - Mechanic", _user2.ToString());
        }
    }
}
