using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EyeCT4RailsLogic.Utilities.MailUtil;

namespace EyeCT4RailsUnitTests.LogicTest
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void IsValidEmailTest()
        {
            bool result = IsValidEmail("hans@mail.com");
            Assert.IsTrue(result);

            result = IsValidEmail("Gekkie");
            Assert.IsFalse(result);
        }
    }
}
