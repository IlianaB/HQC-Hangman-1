using System.Collections.Generic;
using Hangman.Logic.Players.Contracts;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void SortScoreBoard();

        IList<IPersonalScore> GetTopScores(int count);

        bool IsEmpty();

        void RestoreScores(IList<IPersonalScore> restoredResults);

        bool CheckIfPlayerCanEnterHighScores(IPlayer player);
    }
}