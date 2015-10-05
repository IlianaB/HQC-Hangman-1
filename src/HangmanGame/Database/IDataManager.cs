using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Database
{
    public interface IDataManager
    {
        void SaveResult(IPersonalScore score);

        void RestoreResults(ScoreBoardService scoreBoardService);
    }
}