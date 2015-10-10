using Hangman.Logic.ScoreBoardServices;
using NUnit.Framework;

namespace HagmanGameTests.ScoreBoardServices
{
    [TestFixture]
    public class PersonalScoreTest
    {
        [Test]
        public void CorrectPersonalScoreCreationTest()
        {
            var personalScore = new PersonalScore("Ivan", 0);

            Assert.AreEqual("Ivan", personalScore.Name);
            Assert.AreEqual(0, personalScore.Score);
        }

        [Test]
        public void CorrectToStringForPersonalScore()
        {
            var personalScore = new PersonalScore("Ivan", 0);
            var result = personalScore.ToString();

            Assert.AreEqual("Ivan - 0", result);
        }
    }
}
