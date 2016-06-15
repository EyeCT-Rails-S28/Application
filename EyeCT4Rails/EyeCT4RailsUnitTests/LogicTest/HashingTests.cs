using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EyeCT4RailsLogic.Utilities.HashingUtil;

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

            var hash1 = HashString(password, salt);
            var hash2 = HashString(password, salt);

            Assert.AreEqual(hash1,hash2);
        }

        [TestMethod]
        public void SaltyRandomnessTest()
        {
            var salt1 = GetNewSalt();
            var salt2 = GetNewSalt();

            Assert.AreNotEqual(salt1, salt2);
        }
    }
}
