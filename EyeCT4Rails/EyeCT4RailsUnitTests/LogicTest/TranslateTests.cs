using EyeCT4RailsLib.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EyeCT4RailsLogic.Utilities.TranslationUtil;

namespace EyeCT4RailsUnitTests.LogicTest
{
    [TestClass]
    public class TranslateTests
    {
        [TestMethod]
        public void TranslateJobTypeTest()
        {
            var result = TranslateJobType(JobType.Cleanup);
            Assert.AreEqual("Schoonmaak", result);

            result = TranslateJobType(JobType.Maintenance);
            Assert.AreEqual("Reparatie", result);
        }

        [TestMethod]
        public void TranslateJobSizeTest()
        {
            var result = TranslateJobSize(JobSize.Big);
            Assert.AreEqual("Groot", result);

            result = TranslateJobSize(JobSize.Small);
            Assert.AreEqual("Klein", result);
        }
    }
}
