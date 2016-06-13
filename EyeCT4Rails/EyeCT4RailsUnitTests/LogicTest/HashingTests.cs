using EyeCT4RailsLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EyeCT4RailsUnitTests.LogicTest
{
    [TestClass]
    public class HashingTests
    {
        [TestMethod]
        public void GetSaltyTest()
        {
            var salt = "G5F3SXd+Xnr8E3ncquQfzrQfhYgQ3UwXin59JTXJBc3BeJWM1bqIl2116v8W0cwznHMLb60mg/nAfWfbZJdzOA==";
            var password = "gekkehenkie";

            var hash1 = HashingUtil.HashString(password, salt);
            var hash2 = HashingUtil.HashString(password, salt);

            Assert.AreEqual(hash1,hash2);
        }
    }
}
