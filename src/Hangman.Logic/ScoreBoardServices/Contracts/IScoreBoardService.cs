using System.Collections.Generic;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void RemoveLastScores(int maxNumberOfScoresinScoreBoard);

        void SortScoreBoard();

        IList<IPersonalScore> GetAllScores();

        int GetWorstScoreEntry(int position);

        bool IsFull(int numberOfScoresInScoreBoard);

        bool IsEmpty();

        void ReSet();

        void RestoreScores(IList<IPersonalScore> restoredResults);
    }
}