using HangmanGame.HangmanGame.Console;
using HangmanGame.HangmanGame.Contracts;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Console
{
    [TestFixture]
    public class InputProviderTest
    {
        private const string FakePlayerName = "Djordjano";
        private ConsoleInputProvider inputProvider;

        [SetUp]
        public void Init()
        {
            var mockedConsoleInputProvider = new Mock<ConsoleInputProvider>();
            mockedConsoleInputProvider.Setup(r => r.GetPlayerName()).Returns(FakePlayerName);
            mockedConsoleInputProvider.Setup(r => r.ReadCommand()).Returns(FakePlayerName);
            this.inputProvider = mockedConsoleInputProvider.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.inputProvider = null;
        }

        [Test]
        public void TestGetPlayerName()
        {
            Assert.AreEqual(FakePlayerName, this.inputProvider.GetPlayerName(), "Player name get correctly");
        }

        [Test]
        public void TestReadCommand()
        {
            Assert.AreEqual(FakePlayerName, this.inputProvider.ReadCommand(), "Player name read correctly");
        }
    }
}
