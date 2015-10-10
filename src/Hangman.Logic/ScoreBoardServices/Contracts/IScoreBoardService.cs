// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IScoreBoardService.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;
using Hangman.Logic.Players.Contracts;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);

        void RestoreScores(IList<IPersonalScore> restoredResults);

        IList<IPersonalScore> GetTopScores(int count);

        bool IsEmpty();

        bool CheckIfPlayerCanEnterHighScores(IPlayer player);
    }
}