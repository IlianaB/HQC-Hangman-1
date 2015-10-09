using System.Collections.Generic;
using System.Linq;
using Hangman.Logic.Common;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.ScoreBoardServices
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

        public void RemoveLastScores(int maxNumberOfScoresInScoreBoard)
        {
            int maxNumberOfScores = maxNumberOfScoresInScoreBoard > 1 ? maxNumberOfScoresInScoreBoard : 1;
            int currentNumberOfScores = this.currentScoreBoard.Records.Count();

            for (int i = maxNumberOfScores - 1; i < currentNumberOfScores; i++)
            {
                this.currentScoreBoard.Records.RemoveAt(maxNumberOfScores - 1);
            }
        }

        public void SortScoreBoard()
        {
            this.currentScoreBoard.Records = this.currentScoreBoard.Records.OrderBy(ps => ps.Score).ToList();
        }

        public IList<IPersonalScore> GetAllScores()
        {
            return new List<IPersonalScore>(this.currentScoreBoard.Records);
        }

        public int GetWorstScoreEntry(int maxNumberOfScoresInScoreBoard)
        {
            IPersonalScore lastScore;

            if (this.currentScoreBoard.Records.Count <= maxNumberOfScoresInScoreBoard)
            {
                lastScore = this.currentScoreBoard.Records[this.currentScoreBoard.Records.Count - 1];
            }
            else
            {
                lastScore = this.currentScoreBoard.Records[maxNumberOfScoresInScoreBoard];
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

        public void RestoreScores(IList<IPersonalScore> restoredResults)
        {
            this.currentScoreBoard.Records = restoredResults;
        }


        public bool CheckIfPlayerCanEnterHighScores(Players.Contracts.IPlayer player)
        {
            bool playerCanEnterHighScores = true;

            if (this.IsFull(Constants.NumberOfScoresInScoreBoard))
            {
                var worstScore = this.GetWorstScoreEntry(Constants.NumberOfScoresInScoreBoard);
                playerCanEnterHighScores = worstScore >= player.Mistakes;

                if (playerCanEnterHighScores)
                {
                    this.RemoveLastScores(Constants.NumberOfScoresInScoreBoard);
                }
            }

            return playerCanEnterHighScores;
        }

        public IList<IPersonalScore> GetTopScores(int count)
        {
            var topScores =  new List<IPersonalScore>(this.currentScoreBoard.Records.Take(count));

            return topScores;
        }
    }
}