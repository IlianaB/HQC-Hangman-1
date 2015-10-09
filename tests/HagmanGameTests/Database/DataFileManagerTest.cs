using System.IO;
using Hangman.Logic.Database;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Database
{
    [TestFixture]
    public class DataFileManagerTest
    {
        private DataFileManager dataFileManager;
        private IPersonalScore personalScore;

        [SetUp]
        public void Init()
        {
            var mockedPersonalScore = new Mock<IPersonalScore>();
            this.dataFileManager = DataFileManager.SingletonInstance;
            this.personalScore = mockedPersonalScore.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.dataFileManager = null;
            this.personalScore = null;
        }

        [Test]
        public void TestDataFileManagerCreation()
        {
            Assert.IsInstanceOf(typeof(DataFileManager), this.dataFileManager, "DataFileManager is in correct type");
        }

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestSaveResultInvalidFileThrowsError()
        {
            string fakePath = @"C:\tempFake\myReallyFakeFile.txt";
            this.dataFileManager.SaveResult(this.personalScore, fakePath);
        }
    }
}
