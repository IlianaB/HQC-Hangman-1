using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Database
{
    public abstract class DataManager : IDataManager
    {
        public abstract void SaveResult(IPersonalScore score, string filePath);

        public abstract void RestoreResults(IScoreBoardService scoreBoardService, string filePath);
    }
}