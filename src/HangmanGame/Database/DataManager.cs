using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Database
{
    public abstract class DataManager : IDataManager
    {
        public abstract void SaveResult(IPersonalScore score, string filePath);

        public abstract void RestoreResults(ScoreBoardService scoreBoardService, string filePath);
    }
}