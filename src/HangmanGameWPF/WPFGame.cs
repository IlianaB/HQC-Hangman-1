using HangmanGame.HangmanGame;
using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Engines;
using HangmanGame.HangmanGame.Factories;
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
            ScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new WPFRenderer();
            IPlayer player = new Player(false);
            WordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            CommandFactory commandFactory = new CommandFactory();
            IEngine gameEngine = new WPFEngine(scoreBoard, scoreBoardService, renderer, player, randomWordGenerator, commandFactory);
            DataFileManager.SingletonInstance().RestoreResults(scoreBoardService, Constants.FilePathWPFGame);

            this.Engine = gameEngine;
        }
    }
}
