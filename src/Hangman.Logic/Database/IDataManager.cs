using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Database
{
    public interface IDataManager
    {
        void SaveResult(IPersonalScore score, string filePath);

        void RestoreResults(IScoreBoardService scoreBoardService, string filePath);
    }
}