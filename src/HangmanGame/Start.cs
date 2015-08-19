namespace HangmanGame.HangmanGame
{
    class Start
    {
        static void Main()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            GameStrategy gameStrategy = new GameStrategy();
            ConsoleRenderer renderer = new ConsoleRenderer();
            Player player = new Player();
            GameEngine gameEngine = new GameEngine(scoreBoard, gameStrategy, renderer, player);

            gameEngine.Start();
        }
    }
}
