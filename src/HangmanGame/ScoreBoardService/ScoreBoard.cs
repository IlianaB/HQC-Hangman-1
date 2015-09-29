﻿using System.Collections.Generic;
using System.Linq;
using HangmanGame.HangmanGame.ScoreBoardService.Contracts;

namespace HangmanGame.HangmanGame.ScoreBoardService
{
    public class ScoreBoard
    {
        private IList<IPersonalScore> records;

        public const int NumberOfScores = 5;

        public ScoreBoard()
        {
            this.records = new List<IPersonalScore>();
            this.IsEmpty = true;
        }

        public IList<IPersonalScore> Records
        {
            get { return new List<IPersonalScore>(this.records); }
            private set { this.records = value; }
        }

        public bool IsEmpty { get; private set; }

        public void AddNewScore(IPersonalScore record)
        {
            this.records.Add(record);

            this.IsEmpty = false;
        }

        public void SortScoreBoard()
        {
            this.records = this.records.OrderBy(ps => ps.Score).ToList();
        }

        public int GetWorstScoreEntry(int position)
        {
            IPersonalScore lastScore;

            if (this.Records.Count <= position)
            {
                lastScore = this.Records[this.Records.Count - 1];
            }
            else
            {
                lastScore = this.Records[position];
            }

            return lastScore.Score;
        }

        public void ReSet()
        {
            this.records = new List<IPersonalScore>();
            this.IsEmpty = true;
        }
    }
}