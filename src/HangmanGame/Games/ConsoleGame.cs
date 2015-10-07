using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Console;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Engines;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Games
{
    public class ConsoleGame : Game
    {
        public override void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            ScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new ConsoleRenderer();
            IInputProvider inputProvider = new ConsoleInputProvider();
            IPlayer player = new Player(false);
            WordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            CommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new ConsoleEngine(scoreBoard, scoreBoardService, renderer, player, randomWordGenerator, commandFactory, inputProvider);
            DataFileManager.SingletonInstance().RestoreResults(scoreBoardService, Constants.FilePathConsoleGame);

            this.Engine = gameEngine;
            //Menu.Logo.LogoDraw();
            //Menu.InitialMenu.DisplayInitialMenu(gameEngine, commandFactory);
        }
    }
}
