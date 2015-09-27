using System.Collections.Generic;
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
        }

        public bool IsEmpty { get; private set; }

        public void AddNewScore(IPersonalScore record)
        {
            this.records.Add(record);

            this.IsEmpty = false;
        }

        public int GetWorstTopScore(int position)
        {
            int worstTopScore;
            IPersonalScore lastRecord;

            if (this.Records.Count <= position)
            {
                lastRecord = this.Records[this.Records.Count - 1];
            }
            else
            {
                lastRecord = this.Records[position];
            }

            worstTopScore = lastRecord.Score;

            return worstTopScore;
        }

        public void ReSet()
        {
            this.records = new List<IPersonalScore>();
            this.IsEmpty = true;
        }
    }
}
