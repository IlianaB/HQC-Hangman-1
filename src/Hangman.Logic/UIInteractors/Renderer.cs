// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="Renderer.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Contracts;
using Hangman.Logic.Formatters;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.UIInteractors
{
    using System.Collections.Generic;

    /// <summary>
    /// Responsible for rendering everything on the UI.
    /// </summary>
    public abstract class Renderer : IRenderer
    {
        /// <summary>
        /// Instance of IResultFormatter
        /// </summary>
        protected readonly IResultFormatter Formatter;

        /// <summary>
        /// Instance of IWriter
        /// </summary>
        protected readonly IWriter Writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="formatter">Instance of IResultFormatter</param>
        /// <param name="writer">Instance of IWriter</param>
        protected Renderer(IResultFormatter formatter, IWriter writer)
        {
            this.Formatter = formatter;
            this.Writer = writer;
        }

        /// <summary>
        /// Shows on the UI the results of the ScoreBoard.
        /// </summary>
        /// <param name="isEmptyScoreBoard">
        /// Boolean variable indicating if the ScoreBoard is empty or not.
        /// </param>
        /// <param name="records">
        /// Collection of all records in the ScoreBoard.
        /// </param>
        public abstract void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);

        /// <summary>
        /// Shows on the UI the current progress of the game - the letters of the GuessWord.
        /// </summary>
        /// <param name="guessedLetters">
        /// Letters of the GuessWord (hidden or revealed).
        /// </param>
        public abstract void ShowCurrentProgress(char[] guessedLetters);

        /// <summary>
        /// Shows on the UI the received message.
        /// </summary>
        /// <param name="message">
        /// Message as a string.
        /// </param>
        public abstract void ShowMessage(string message);

        /// <summary>
        /// Draws the Hangman on the UI.
        /// </summary>
        /// <param name="mistakes">
        /// The number of Player's mistakes.
        /// </param>
        public abstract void DrawHangman(int mistakes);
    }
}
