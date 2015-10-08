using System.Collections.Generic;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void RemoveLastRecords(int maxNumberOfScoresinScoreBoard);

        void SortScoreBoard();

        IList<IPersonalScore> GetAllRecords();

        int GetWorstScoreEntry(int position);

        bool IsFull(int numberOfScoresInScoreBoard);

        bool IsEmpty();

        void ReSet();

        void RestoreRecords(IList<IPersonalScore> restoredResults);
    }
}