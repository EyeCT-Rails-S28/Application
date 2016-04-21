using System;
using System.Collections.Generic;
using System.Linq;
using EyeCT4RailsLib;
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
            _user1 = new User(1, "Henk Stenk", "HenkyBaas@gmail.com", Privilege.Administrator);
            _user2 = new User(2, "Piet Piraat", "Arrrr@gmail.com", Privilege.Mechanic);
        }

        [TestMethod]
        public void UserConstructorTest()
        {
            Assert.AreEqual(1, _user1.Id);
            Assert.AreEqual(Privilege.Administrator, _user1.Privilege);
            Assert.AreEqual("Piet Piraat", _user2.Name);
        }

        [TestMethod]
        public void HasPrivilegeTest()
        {
            var enums = new List<Privilege> {
                Privilege.Administrator, Privilege.Cleanup, Privilege.DepotMananger, Privilege.Driver,
                Privilege.Mechanic
            };
            
            enums.ForEach(x => Assert.AreEqual(true, _user1.HasPrivilege(x)));
            enums.FindAll(x => x != Privilege.Mechanic).ToList().ForEach(y => Assert.AreNotEqual(true, _user2.HasPrivilege(y)));
            Assert.AreEqual(true, _user2.HasPrivilege(Privilege.Mechanic));
        }

        [TestMethod]
        public void UserToStringTest()
        {
            Assert.AreEqual("1 - Henk Stenk - Administrator", _user1.ToString());
            Assert.AreEqual("2 - Piet Piraat - Mechanic", _user2.ToString());
        }
    }
}
