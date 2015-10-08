using Hangman.Logic.Games;

namespace Hangman.Console.UI
{
    public class EntryPoint
    {
        private static void Main()
        {
            Game game = new ConsoleGame();
            game.Initialize();
            game.Start();
        }
    }
}
