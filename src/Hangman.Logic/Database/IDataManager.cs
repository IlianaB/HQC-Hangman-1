// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IDataManager.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Database
{
    /// <summary>
    /// Declares all methods its implementation must have.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Saves the received IPersonalScore in the database.
        /// </summary>
        /// <param name="score">
        /// The score of the current player.
        /// </param>
        /// <param name="filePath">
        /// The path to the file, which acts as a database.
        /// </param>
        void SaveResult(IPersonalScore score, string filePath);

        /// <summary>
        /// Reads the result from the database and restores them as a C# objects.
        /// </summary>
        /// <param name="scoreBoardService">
        /// The current ScoreBoardService.
        /// </param>
        /// <param name="filePath">
        /// The path to the file, which acts as a database.
        /// </param>
        void RestoreResults(IScoreBoardService scoreBoardService, string filePath);
    }
}