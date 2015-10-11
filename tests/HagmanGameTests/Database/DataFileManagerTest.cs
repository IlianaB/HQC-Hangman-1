using Hangman.Logic.Database;
using Hangman.Logic.ScoreBoardServices;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;

namespace HagmanGameTests.Database
{
    [TestFixture]
    public class DataFileManagerTest
    {
        private DataFileManager dataFileManager;
        private PersonalScore personalScore;

        [SetUp]
        public void Init()
        {
            this.dataFileManager = DataFileManager.SingletonInstance;
            this.personalScore = new PersonalScore("Tester", 1);
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

        [Test, Isolated]
        public void TestSaveResult()
        {
            var called = true;
            Isolate.WhenCalled(() => this.dataFileManager.SaveResult(null, null)).DoInstead(x => called = false);

            this.dataFileManager.SaveResult(this.personalScore, "Some");

            Assert.IsTrue(called);
        }
    }
}
