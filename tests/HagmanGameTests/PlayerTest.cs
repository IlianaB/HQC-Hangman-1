using HangmanGame.HangmanGame;
using NUnit.Framework;

namespace HagmanGameTests
{
    [TestFixture]
    public class PlayerTest
    {
        private Player player;

        [SetUp]
        public void Init()
        {
            player = new Player();
        }

        [TearDown]
        public void CleanUp()
        {
            player = null;
        }

        [Test]
        public void TestIncreaseMistakes()
        {
            player.IncreaseMistakes();

            Assert.AreEqual(1, player.Mistakes, "Player mistakes should be 1 when increased once after initialization");
        }
    }
}
