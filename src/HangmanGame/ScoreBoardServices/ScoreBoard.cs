using System.Collections.Generic;

using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.ScoreBoardServices
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
            internal set { this.records = value; }
        }

        //public void AddNewScore(IPersonalScore record)
        //{
        //    this.Records.Add(record);

        //}

        //public void SortScoreBoard()
        //{
        //    this.Records = this.Records.OrderBy(ps => ps.Score).ToList();
        //}

        //public int GetWorstScoreEntry(int position)
        //{
        //    IPersonalScore lastScore;

        //    if (this.Records.Count <= position)
        //    {
        //        lastScore = this.Records[this.Records.Count - 1];
        //    }
        //    else
        //    {
        //        lastScore = this.Records[position];
        //    }

        //    return lastScore.Score;
        //}

        //public bool IsFull(int numberOfScoresInScoreBoard)
        //{
        //    var isFull = this.Records.Count() >= numberOfScoresInScoreBoard;
        //    return isFull;
        //}

        //public bool IsEmpty()
        //{
        //    var isEmpty = this.Records.Count() == 0;
        //    return isEmpty;
        //}

        //public void ReSet()
        //{
        //    this.Records = new List<IPersonalScore>();
        //}

    }
}
