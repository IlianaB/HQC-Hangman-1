using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.ScoreBoardServices
{
    public class ScoreBoardService
    {
        private ScoreBoard currentScoreBoard;

        public ScoreBoardService(ScoreBoard scoreBoard)
        {
            currentScoreBoard = scoreBoard;
        }

       
        public void AddNewScore(IPersonalScore record)
        {
            currentScoreBoard.Records.Add(record);
           
        }

        public void SortScoreBoard()
        {
            currentScoreBoard.Records = currentScoreBoard.Records.OrderBy(ps => ps.Score).ToList();
        }

        public int GetWorstScoreEntry(int position)
        {
            IPersonalScore lastScore;

            if (currentScoreBoard.Records.Count <= position)
            {
                lastScore = currentScoreBoard.Records[currentScoreBoard.Records.Count - 1];
            }
            else
            {
                lastScore = currentScoreBoard.Records[position];
            }

            return lastScore.Score;
        }

        public bool IsFull(int numberOfScoresInScoreBoard)
        {
            var isFull = currentScoreBoard.Records.Count() >= numberOfScoresInScoreBoard;
            return isFull;
        }

        public bool IsEmpty()
        {
            var isEmpty = currentScoreBoard.Records.Count() == 0;
            return isEmpty;
        }

        public void ReSet()
        {
            currentScoreBoard.Records = new List<IPersonalScore>();
        }
    }
}
