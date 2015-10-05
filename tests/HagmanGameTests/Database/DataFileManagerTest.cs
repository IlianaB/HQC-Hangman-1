using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.ScoreBoardServices;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Database
{
    [TestFixture]
    public class DataFileManagerTest
    {
        private DataFileManager dataFileManager;
        private PersonalScore personalScore;
        private ScoreBoardService scoreBoardService;

        [SetUp]
        public void Init()
        {
            var mockedDataFileManager = new Mock<DataFileManager>();
            var mockedPersonalScore = new Mock<PersonalScore>();
            var mockedScoreBoardService = new Mock<ScoreBoardService>();

            this.dataFileManager = mockedDataFileManager.Object;
            //this.personalScore = mockedPersonalScore.Object;
            //this.scoreBoardService = mockedScoreBoardService.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.dataFileManager = null;
            this.personalScore = null;
            this.scoreBoardService = null;
        }

        [Test]
        public void TestDataFileManagerCreation()
        {
            Assert.IsInstanceOf(typeof(DataFileManager), this.dataFileManager, "DataFileManager is in correct type");
        }
    }
}
