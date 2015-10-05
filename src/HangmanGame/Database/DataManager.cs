using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Database
{
    public abstract class DataManager : IDataManager
    {
        public abstract void SaveResult(IPersonalScore score);

        public abstract void RestoreResults(ScoreBoardService scoreBoardService);
    }
}