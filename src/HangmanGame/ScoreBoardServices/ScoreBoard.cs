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
    }
}
