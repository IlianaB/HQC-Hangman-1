namespace HangmanGame.HangmanGame
{
    using System.Collections.Generic;

    public class ScoreBoard
    {
        private IList<Record> records;

        public const int NumberOfScores = 5;

        public ScoreBoard()
        {
            this.records = new List<Record>();
            this.IsEmpty = true;
        }

        public IList<Record> Records
        {
            get { return new List<Record>(this.records); }
        }

        public bool IsEmpty { get; private set; }

        public void AddNewScore(Record record)
        {
            this.records.Add(record);

            this.IsEmpty = false;
        }

        public int GetWorstTopScore(int position)
        {
            int worstTopScore;
            Record lastRecord;

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
            this.records = new List<Record>();
            this.IsEmpty = true;
        }
    }
}
