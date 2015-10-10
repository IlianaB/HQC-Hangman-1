// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ScoreBoard.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.ScoreBoardServices
{
    public class ScoreBoard : IScoreBoard
    {
        private IList<IPersonalScore> records;

        public ScoreBoard()
        {
            this.records = new List<IPersonalScore>();
        }

        public IList<IPersonalScore> Records
        {
            get { return this.records; }
            set { this.records = value; }
        }
    }
}
