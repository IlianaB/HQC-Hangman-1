using System.Collections.Generic;

namespace HangmanGame.HangmanGame.ScoreBoardServices.Contracts
{
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void SortScoreBoard();

        IList<IPersonalScore> GetAllRecords();

        int GetWorstScoreEntry(int position);

        bool IsFull(int numberOfScoresInScoreBoard);

        bool IsEmpty();

        void ReSet();

        void RestoreRecords(IList<IPersonalScore> restoredResults);
    }
}