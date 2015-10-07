using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame
{
    public class WPFEngine : GameEngine
    {
        public WPFEngine(IScoreBoard scoreBoard, ScoreBoardService scoreBoardService, IRenderer renderer,
                        IPlayer player, WordGenerator wordGenerator, CommandFactory commandFactory)
            : base(scoreBoard, scoreBoardService, renderer, player, wordGenerator, commandFactory)
        {
        }

        protected override void SaveResult(IPersonalScore newRecord)
        {
            //Need to change the file path!
            //DataFileManager.SingletonInstance().SaveResult(newRecord, Constants.FilePathWPFGame);
        }
    }
}
