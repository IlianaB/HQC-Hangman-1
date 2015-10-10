// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ScoreBoard.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.ScoreBoardServices
{
    /// <summary>
    /// Holds a collection with personal scores.
    /// </summary>
    public class ScoreBoard : IScoreBoard
    {
        private IList<IPersonalScore> records;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreBoard"/> class.
        /// </summary>
        public ScoreBoard()
        {
            this.records = new List<IPersonalScore>();
        }

        /// <summary>
        /// Gets or sets a collection with personal scores.
        /// </summary>
        public IList<IPersonalScore> Records
        {
            get { return this.records; }
            set { this.records = value; }
        }
    }
}
