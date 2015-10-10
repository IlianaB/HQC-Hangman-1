using Hangman.Console.UI.Console;
using Hangman.Logic.Contracts;

using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Console.UI
{
    [TestFixture]
    public class InputProviderTest
    {
        private const string FakePlayerName = "Djordjano";
        private IReader reader;
        private IInputProvider inputProvider;

        [SetUp]
        public void Init()
        {
            var mockReader = new Mock<IReader>();
            mockReader.Setup(r => r.ReadText()).Returns(FakePlayerName);
            this.reader = mockReader.Object;

            this.inputProvider = new ConsoleInputProvider(this.reader);
        }

        [TearDown]
        public void CleanUp()
        {
            this.reader = null;
        }

        [Test]
        public void ReadCommandTest()
        {
            Assert.AreEqual(this.inputProvider.ReadCommand(), FakePlayerName.ToLower());
        }

        [Test]
        public void ConsoleInputProviderTest()
        {
            var consoleInputProvider = new ConsoleInputProvider();
            Assert.IsInstanceOf(typeof(ConsoleInputProvider), consoleInputProvider);
        }
    }
}
