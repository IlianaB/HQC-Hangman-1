// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IRenderer.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares all methods its implementation must have.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Shows on the UI the results of the ScoreBoard.
        /// </summary>
        /// <param name="isEmptyScoreBoard">
        /// Boolean variable indicating if the ScoreBoard is empty or not.
        /// </param>
        /// <param name="records">
        /// Collection of all records in the ScoreBoard.
        /// </param>
        void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);

        /// <summary>
        /// Shows on the UI the current progress of the game - the letters of the GuessWord.
        /// </summary>
        /// <param name="guessedLetters">
        /// Letters of the GuessWord (hidden or revealed).
        /// </param>
        void ShowCurrentProgress(char[] guessedLetters);

        /// <summary>
        /// Shows on the UI the received message.
        /// </summary>
        /// <param name="message">
        /// Message as a string.
        /// </param>
        void ShowMessage(string message);

        /// <summary>
        /// Draws the Hangman on the UI.
        /// </summary>
        /// <param name="mistakes">
        /// The number of Player's mistakes.
        /// </param>
        void DrawHangman(int mistakes);
    }
}
