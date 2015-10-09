using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Database;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words.Contracts;

namespace Hangman.WPF.UI
{
    public class WpfEngine : GameEngine
    {
        public WpfEngine(
            IScoreBoardService scoreBoardService, 
            IRenderer renderer, 
            IPlayer player, 
            IWordGenerator wordGenerator, 
            ICommandFactory commandFactory)
            : base(scoreBoardService, renderer, player, wordGenerator, commandFactory)
        {
        }

        protected override void SaveResult(IPersonalScore newRecord)
        {
            base.SaveResult(newRecord);
            DataFileManager.SingletonInstance.SaveResult(newRecord, Constants.FilePathWPFGame);
        }
    }
}
