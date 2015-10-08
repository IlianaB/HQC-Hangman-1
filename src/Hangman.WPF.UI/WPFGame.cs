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

namespace Hangman.WPF.UI
{
    public class WPFGame : Game
    {
        public override void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            IScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new WPFRenderer(new AllCapsFormatter());
            IPlayer player = new Player(false);
            IWordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            ICommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new WPFEngine(scoreBoardService, renderer, player, randomWordGenerator, commandFactory);
            DataFileManager.SingletonInstance.RestoreResults(scoreBoardService, Constants.FilePathWPFGame);

            this.Engine = gameEngine;
        }
    }
}
