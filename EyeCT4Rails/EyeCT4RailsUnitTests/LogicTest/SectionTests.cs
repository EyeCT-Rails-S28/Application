using System.Collections.Generic;
using EyeCT4RailsLib.Classes;
using EyeCT4RailsLib.Enums;
using EyeCT4RailsLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EyeCT4RailsLogic.Utilities.SectionUtil;

namespace EyeCT4RailsUnitTests.LogicTest
{
    [TestClass]
    public class SectionTests
    {
        private Depot _depot;
        private Track _track;
        private List<Section> _sections;

        [TestInitialize]
        public void SectionUtilInit()
        {
            _depot = new Depot(1, "Aardappel");
            _track = new Track(2);
           _sections = new List<Section>();

            for (int i = 0; i < 3; i++)
            {
                Section section = new Section(i, false);

                if(i > 0)
                    section.AddPreviousSection(_sections[i - 1]);

                _sections.Add(section);
            }

            _sections.ForEach(x => x.AddNextSection(_sections.Find(y => y.Id == x.Id + 1)));
            _sections.ForEach(x => _track.AddSection(x));
            _depot.AddTrack(_track);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFreeSectionException))]
        public void GetFreeSectionTest()
        {
            Section result = GetFreeSection(_depot, TramType.Combino);

            //Result should be the last section of the track.
            Assert.AreEqual(2, result.Id);

            _sections.ForEach(x => x.Blocked = true);

            //Raise exception
            GetFreeSection(_depot, TramType.Combino);
        }

        [TestMethod]
        public void CheckSectionFreedomTest()
        {
            //Should be true.
            bool result = CheckSectionFreedom(_sections[1]);
            Assert.IsTrue(result);

            //Should be true;
            _sections[0].Blocked = true;
            result = CheckSectionFreedom(_sections[1]);
            Assert.IsTrue(result);

            //Should be false.
            _sections.ForEach(x => x.Blocked = true);
            result = CheckSectionFreedom(_sections[1]);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckSectionBlockingTest()
        {
            //Should be true.
            bool result = CheckSectionBlocking(_track.Sections[0], _track);
            Assert.IsTrue(result);

            //Should be true.
            _sections[2].Blocked = true;
            result = CheckSectionBlocking(_track.Sections[0], _track);
            Assert.IsTrue(result);

            //Should be false.
            _sections[1].Tram = new Tram(1, TramType.Combino, Status.Dienst, new Line(2), false);
            result = CheckSectionBlocking(_track.Sections[0], _track);
            Assert.IsFalse(result);
        }
    }
}
