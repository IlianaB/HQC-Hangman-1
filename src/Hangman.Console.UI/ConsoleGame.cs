using Hangman.Console.UI.Console;
using Hangman.Console.UI.Engines;
using Hangman.Logic.Contracts;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.Formatters;
using Hangman.Logic.Games;
using Hangman.Logic.Players;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Console.UI
{
    public class ConsoleGame : Game
    {
        public override void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            IScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new ConsoleRenderer(new CapitalizeFormatter(), new Writer());
            IInputProvider inputProvider = new ConsoleInputProvider(new Reader());
            IPlayer player = new Player();
            IWordProvider wordProvider = new WordProvider();
            IWordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            ICommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new ConsoleEngine(scoreBoardService, renderer, player, randomWordGenerator, commandFactory, inputProvider);

            this.Engine = gameEngine;
        }
    }
}
