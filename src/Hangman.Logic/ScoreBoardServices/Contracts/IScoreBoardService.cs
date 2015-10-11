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
        /// <summary>
        /// Adds new IPersonalScore to the collection contained in the 
        /// IScoreBoard that it currently works with.
        /// </summary>
        /// <param name="record">Instance of IPersonalScore</param>
        void AddNewScore(IPersonalScore record);

        /// <summary>
        /// Sets the collection of IPersonalScore of the current instance of IScoreBoard
        /// to a provided IList.
        /// </summary>
        /// <param name="restoredResults">An IList of IPersonalScore</param>
        void RestoreScores(IList<IPersonalScore> restoredResults);

        /// <summary>
        /// Gets the IPersonalScore records from the database, sorts them and compares their number with 
        /// the provided maximum number of items.
        /// </summary>
        /// <param name="maxNumberOfScoresInScoreBoard">>Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>IList of IPersonalScore records</returns>
        IList<IPersonalScore> GetTopScores(int maxNumberOfScoresInScoreBoard);

        /// <summary>
        /// Checks whether the number of Records in the current instance of IScoreBoard
        ///  is equal to zero.
        /// </summary>
        /// <returns>True if there are no records.</returns>
        bool IsEmpty();

        /// <summary>
        /// Checks whether the number of Records in the current instance of IScoreBoard
        ///  is equal or above the provided limit.
        /// </summary>
        /// <param name="numberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>True if the conditions are met.</returns>
        bool IsFull(int numberOfScoresInScoreBoard);

        /// <summary>
        /// Checks if the current player score can be submitted to the IScoreBoard on basis of the current number of items
        /// and the maximum number of items allowed and the number of the mistakes of the last IPersonalScore
        /// </summary>
        /// <param name="player">Current player</param>
        /// <param name="maxNumberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>True if the player score can be submitted to the IScoreBoard</returns>
        bool CheckIfPlayerCanEnterHighScores(IPlayer player, int maxNumberOfScoresInScoreBoard);
    }
}