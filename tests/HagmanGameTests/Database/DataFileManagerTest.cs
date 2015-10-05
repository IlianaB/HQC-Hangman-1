using System.IO;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Database
{
    [TestFixture]
    public class DataFileManagerTest
    {
        private DataFileManager dataFileManager;
        private IPersonalScore personalScore;
        private ScoreBoardService scoreBoardService;

        [SetUp]
        public void Init()
        {
            var mockedPersonalScore = new Mock<IPersonalScore>();
            var mockedScoreBoardService = new Mock<ScoreBoardService>();

            this.dataFileManager = DataFileManager.SingletonInstance();
            this.personalScore = mockedPersonalScore.Object;
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

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestSaveResult_InvalidFile_ThrowsError()
        {
            string fakePath = @"C:\tempFake\myReallyFakeFile.txt";

            this.dataFileManager.SaveResult(this.personalScore, fakePath);
        }
    }
}
