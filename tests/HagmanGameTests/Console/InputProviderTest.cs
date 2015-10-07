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
        private IInputProvider inputProvider;

        [SetUp]
        public void Init()
        {
            var mockedConsoleInputProvider = new Mock<IInputProvider>();
            mockedConsoleInputProvider.Setup(r => r.ReadCommand()).Returns(FakePlayerName);
            this.inputProvider = mockedConsoleInputProvider.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.inputProvider = null;
        }

        [Test]
        public void TestReadCommand()
        {
            Assert.AreEqual(FakePlayerName, this.inputProvider.ReadCommand(), "Player name read correctly");
        }
    }
}
