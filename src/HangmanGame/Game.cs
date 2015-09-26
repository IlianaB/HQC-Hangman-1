namespace HangmanGame.HangmanGame
{
    public class Game
    {
        public void Initialize()
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
