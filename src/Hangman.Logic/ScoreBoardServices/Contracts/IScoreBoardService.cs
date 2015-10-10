using System.Collections.Generic;
using Hangman.Logic.Players.Contracts;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void RestoreScores(IList<IPersonalScore> restoredResults);

        IList<IPersonalScore> GetTopScores(int count);

        bool IsEmpty();

        bool CheckIfPlayerCanEnterHighScores(IPlayer player);
    }
}