namespace HangmanGame.HangmanGame
{
    public class EntryPoint
    {
        internal static void Main()
        {
            Game game = new ConsoleGame();
            game.Initialize();
            game.Start();
        }
    }
}