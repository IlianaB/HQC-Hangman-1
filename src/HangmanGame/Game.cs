using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardService;
using HangmanGame.HangmanGame.States.Activation;

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
            CommandFactory commandFactory = new CommandFactory();
            GameEngine gameEngine = new GameEngine(scoreBoard, gameStrategy, renderer, player, commandFactory);
            ActivationState activationState = new ActiveState(gameEngine);

            gameEngine.Start(activationState);
        }
    }
}
