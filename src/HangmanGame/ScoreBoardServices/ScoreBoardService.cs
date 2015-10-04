using System.Collections.Generic;
using System.Linq;

using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.ScoreBoardServices
{
    public class ScoreBoardService : IScoreBoardService
    {
        private IScoreBoard currentScoreBoard;

        public ScoreBoardService(IScoreBoard scoreBoard)
        {
            this.currentScoreBoard = scoreBoard;
        }
 
        public void AddNewScore(IPersonalScore record)
        {
            this.currentScoreBoard.Records.Add(record);
        }

        public void SortScoreBoard()
        {
            this.currentScoreBoard.Records = this.currentScoreBoard.Records.OrderBy(ps => ps.Score).ToList();
        }

        public int GetWorstScoreEntry(int position)
        {
            IPersonalScore lastScore;

            if (this.currentScoreBoard.Records.Count <= position)
            {
                lastScore = this.currentScoreBoard.Records[this.currentScoreBoard.Records.Count - 1];
            }
            else
            {
                lastScore = this.currentScoreBoard.Records[position];
            }

            return lastScore.Score;
        }

        public bool IsFull(int numberOfScoresInScoreBoard)
        {
            var isFull = this.currentScoreBoard.Records.Count() >= numberOfScoresInScoreBoard;
            
            return isFull;
        }

        public bool IsEmpty()
        {
            var isEmpty = this.currentScoreBoard.Records.Count() == 0;
            
            return isEmpty;
        }

        public void ReSet()
        {
            this.currentScoreBoard.Records.Clear();
        }
    }
}
