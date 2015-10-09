using Hangman.Logic.Commands;
using Hangman.Logic.Contracts;
using Hangman.Logic.Engines;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Commands
{
    [TestFixture]
    public class CommandsTest
    {
        [Test]
        public void TestStartCommandInstance()
        {
            var mockICommandExecutable = new Mock<ICommandExecutable>();
            var mockStartCommand = new Mock<StartCommand>(mockICommandExecutable.Object);
            var startCommand = mockStartCommand.Object;

            Assert.IsInstanceOf(typeof(StartCommand), startCommand, "StartCommand created");
        }

        [Test]
        public void TestStartCommandExecute()
        {
            var mockICommandExecutable = new Mock<ICommandExecutable>();
            var mockIEngine = new Mock<IEngine>();
            var mockStartCommand = new Mock<StartCommand>(mockICommandExecutable.Object);
            var startCommand = mockStartCommand.Object;

            startCommand.Execute();

            Assert.False(mockIEngine.Object.CheckWinningCondition());
        }
    }
}
