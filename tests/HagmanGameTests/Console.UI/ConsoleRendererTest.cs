using System.Collections.Generic;

using Hangman.Console.UI.Console;
using Hangman.Logic.ScoreBoardServices.Contracts;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;

namespace HagmanGameTests.Console.UI
{
    [TestFixture]
    public class ConsoleRendererTest
    {
        private ConsoleRenderer consoleRenderer;

        [SetUp]
        public void Init()
        {
            this.consoleRenderer = new ConsoleRenderer();
        }

        [TearDown]
        public void CleanUp()
        {
            this.consoleRenderer = null;
        }

        [Test]
        public void TestShowMessage()
        {
            var called = false;
            Isolate.WhenCalled(() => this.consoleRenderer.ShowMessage("message")).DoInstead(r => called = true);
            this.consoleRenderer.ShowMessage("Something");
            Assert.IsTrue(called);
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
