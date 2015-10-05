using HangmanGame.HangmanGame.Commands;
using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Commands
{
    [TestFixture]
    public class CommandsTest
    {
        private ICommandExecutable engine;
        private ICommand command;

        [SetUp]
        public void Init()
        {
            var mockedEngine = new Mock<ICommandExecutable>();
            this.engine = mockedEngine.Object;
            
            var mockedCommand = new Mock<StartCommand>(this.engine);
            mockedCommand.Setup(r => r.Execute()).Verifiable();
            this.command = mockedCommand.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.command = null;
            this.engine = null;
        }

        [Test]
        public void TestStartCommand()
        {
            this.command.Execute();
            Assert.IsInstanceOf(typeof(StartCommand), this.command, "StartCommand created");
        }
    }
}
