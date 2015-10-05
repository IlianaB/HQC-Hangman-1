using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Console;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame
{
    public class Game
    {
        public void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            ScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new ConsoleRenderer();
            IInputProvider inputProvider = new ConsoleInputProvider();
            Player player = new Player();
            WordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            CommandFactory commandFactory = new CommandFactory();
            GameEngine gameEngine = new GameEngine(scoreBoard, scoreBoardService, renderer, inputProvider, player, randomWordGenerator, commandFactory);
            DataFileManager.SingletonInstance().RestoreResults(scoreBoardService);

            Menu.Logo.LogoDraw();
            Menu.InitialMenu.DisplayInitialMenu(gameEngine, commandFactory);
        }
    }
}
