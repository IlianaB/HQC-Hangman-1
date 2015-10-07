using HangmanGame.HangmanGame;
using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGameWPF
{
    public class Game
    {
        public IEngine Engine { get; set; }

        public void Initialize()
        {
            IScoreBoard scoreBoard = new ScoreBoard();
            ScoreBoardService scoreBoardService = new ScoreBoardService(scoreBoard);
            IRenderer renderer = new WPFRenderer();
            IPlayer player = new Player(false);
            WordProvider wordProvider = new WordProvider();
            WordGenerator randomWordGenerator = new WordGenerator(wordProvider);
            CommandFactory commandFactory = new CommandFactory();
            //IEngine gameEngine = new WPFEngine(scoreBoard, scoreBoardService, renderer, player, randomWordGenerator, commandFactory);
            //DataFileManager.SingletonInstance().RestoreResults(scoreBoardService, Constants.FilePath);

            //this.Engine = gameEngine;
        }

        public void Start()
        {
            //this.Engine.StartGame();
        }
    }
}
