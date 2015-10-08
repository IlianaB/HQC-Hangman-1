using System.Collections.Generic;

using Hangman.Console.UI.Console;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Moq;
using NUnit.Framework;

namespace HagmanGameTests.Console
{
    [TestFixture]
    public class ConsoleRendererTest
    {
        private ConsoleRenderer consoleRenderer;

        [SetUp]
        public void Init()
        {
            var mockedConsoleRenderer = new Mock<ConsoleRenderer>();
            mockedConsoleRenderer.Setup(r => r.ShowMessage(It.IsAny<string>())).Verifiable();
            mockedConsoleRenderer.Setup(r => r.ShowCurrentProgress(It.IsAny<char[]>())).Verifiable();
            mockedConsoleRenderer.Setup(r => r.DrawHangman(It.IsAny<int>())).Verifiable();
            mockedConsoleRenderer.Setup(r => r.ShowScoreBoardResults(false, new List<IPersonalScore>())).Verifiable();
            this.consoleRenderer = mockedConsoleRenderer.Object;
        }

        [TearDown]
        public void CleanUp()
        {
            this.consoleRenderer = null;
        }

        [Test]
        public void TestShowMessage()
        {
            this.consoleRenderer.ShowMessage("Something");
        }

        [Test]
        public void TestShowCurrentProgress()
        {
            this.consoleRenderer.ShowCurrentProgress(new[] { 'p', 'r', 'o', 'g', 'r', 'e', 's', 's' });
        }

        [Test]
        public void TestDrawHangman()
        {
            this.consoleRenderer.DrawHangman(1);
        }

        [Test]
        public void TestShowScoreBoardResults()
        {
            this.consoleRenderer.ShowScoreBoardResults(false, new List<IPersonalScore>());
        }
    }
}
