using Hangman.Logic.Players;
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
            this.player = new Player();
        }

        [TearDown]
        public void CleanUp()
        {
            this.player = null;
        }

        [Test]
        public void TestIncreaseMistakes()
        {
            this.player.IncreaseMistakes();

            Assert.AreEqual(1, this.player.Mistakes, "Player mistakes should be 1 when increased once after initialization");
        }

        [Test]
        public void TestResetPlayerMistakes()
        {
            this.player.IncreaseMistakes();
            this.player.IncreaseMistakes();
            this.player.IncreaseMistakes();
            this.player.IncreaseMistakes();

            this.player.Reset();

            Assert.AreEqual(0, this.player.Mistakes, "Player mistakes should be 0 when reseted");
        }
    }
}
