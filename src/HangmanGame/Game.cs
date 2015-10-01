using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.States.Activation;

namespace HangmanGame.HangmanGame
{
    public class Game
    {
        public void Initialize()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            ScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            ConsoleRenderer renderer = new ConsoleRenderer();
            Player player = new Player();
            WordGenerator randomWordGenerator = new WordGenerator();
            CommandFactory commandFactory = new CommandFactory();
            GameEngine gameEngine = new GameEngine(scoreBoard, scoreBoardService, renderer, player, randomWordGenerator, commandFactory);
            ActivationState activationState = new ActiveState(gameEngine);

            gameEngine.StartGame(activationState);
        }
    }
}
