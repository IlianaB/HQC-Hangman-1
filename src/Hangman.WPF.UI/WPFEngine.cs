using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Database;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.WPF.Engine
{
    public class WPFEngine : GameEngine
    {
        public WPFEngine(
            IScoreBoardService scoreBoardService, 
            IRenderer renderer, 
            IPlayer player, 
            WordGenerator wordGenerator, 
            ICommandFactory commandFactory)
            : base(scoreBoardService, renderer, player, wordGenerator, commandFactory)
        {
        }

        protected override void SaveResult(IPersonalScore newRecord)
        {
            DataFileManager.SingletonInstance.SaveResult(newRecord, Constants.FilePathWPFGame);
        }
    }
}
