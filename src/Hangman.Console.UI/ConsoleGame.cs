using Hangman.Console.UI.Console;
using Hangman.Console.UI.Engines;
using Hangman.Logic;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Database;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.Formatters;
using Hangman.Logic.Games;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Console.UI
{
    public class ConsoleGame : Game
    {
        public override void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            IScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new ConsoleRenderer(new CapitalizeFormatter());
            IInputProvider inputProvider = new ConsoleInputProvider();
            IPlayer player = new Player(false);
            IWordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            ICommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new ConsoleEngine(scoreBoardService, renderer, player, randomWordGenerator, commandFactory, inputProvider);
            DataFileManager.SingletonInstance.RestoreResults(scoreBoardService, Constants.FilePathConsoleGame);

            this.Engine = gameEngine;

            //Menu.Logo.LogoDraw();

            //Menu.InitialMenu.DisplayInitialMenu(gameEngine, commandFactory);
        }
    }
}
