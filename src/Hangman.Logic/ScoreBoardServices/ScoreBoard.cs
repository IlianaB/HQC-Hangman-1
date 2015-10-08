﻿using System.Collections.Generic;

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