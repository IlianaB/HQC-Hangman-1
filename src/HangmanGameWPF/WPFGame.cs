using HangmanGame.HangmanGame;
using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Engines;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.Formatters;
using HangmanGame.HangmanGame.Games;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGameWPF
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
