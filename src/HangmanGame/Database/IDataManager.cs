using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Database
{
    public interface IDataManager
    {
        void SaveResult(IPersonalScore score, string filePath);

        void RestoreResults(IScoreBoardService scoreBoardService, string filePath);
    }
}