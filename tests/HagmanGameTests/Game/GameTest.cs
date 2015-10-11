using Hangman.Console.UI;
using Hangman.Console.UI.Engines;
using Hangman.WPF.UI;
using NUnit.Framework;
using TypeMock.ArrangeActAssert;

namespace HagmanGameTests.Game
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void TestIfWpfGameInitializeMethodInitializesGameWithWpfEngine()
        {
            var game = new WpfGame();
            game.Initialize();

            Assert.IsTrue(game.Engine is WpfEngine);
        }

        [Test]
        public void TestIfWpfGameStartMethodCallsEnginesStartMethod()
        {
            int calls = 0;
            var game = new WpfGame();

            Isolate.WhenCalled(() => game.Engine.StartGame()).DoInstead(context =>
            {
                calls++;
            });

            game.Start();
            
            Assert.AreEqual(1, calls);
        }

        [Test]
        public void TestIfConsoleGameInitializeMethodInitializesGameWithConsoleEngine()
        {
            var game = new ConsoleGame();
            game.Initialize();

            Assert.IsTrue(game.Engine is ConsoleEngine);
        }
    }
}
