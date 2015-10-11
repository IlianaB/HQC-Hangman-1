// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ScoreBoardService.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;
using System.Linq;
using Hangman.Logic.Common;
using Hangman.Logic.Database;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.ScoreBoardServices
{
    /// <summary>
    /// Implementation of IScoreBoardService.
    /// Defines all methods to work with the provided IScoreBoard.
    /// </summary>
    public class ScoreBoardService : IScoreBoardService
    {
        /// <summary>
        /// Keeps the current instance of IScoreBoard
        /// </summary>
        private readonly IScoreBoard currentScoreBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreBoardService"/> class.
        /// </summary>
        /// <param name="scoreBoard">Instance of IScoreBoard</param>
        public ScoreBoardService(IScoreBoard scoreBoard)
        {
            this.currentScoreBoard = scoreBoard;
        }

        /// <summary>
        /// Adds new IPersonalScore to the collection contained in the 
        /// IScoreBoard that it currently works with.
        /// </summary>
        /// <param name="record">Instance of IPersonalScore</param>
        public void AddNewScore(IPersonalScore record)
        {
            this.currentScoreBoard.Records.Add(record);
        }

        /// <summary>
        /// Compares the number of IPersonalScore items contained in the IScoreBoard with 
        /// a provided maximum number of items and removes all items that are not required 
        /// plus one more. In order to make place for a new item.
        /// </summary>
        /// <param name="maxNumberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        public void RemoveLastScores(int maxNumberOfScoresInScoreBoard)
        {
            int maxNumberOfScores = maxNumberOfScoresInScoreBoard > 1 ? maxNumberOfScoresInScoreBoard : 1;
            int currentNumberOfScores = this.currentScoreBoard.Records.Count();

            for (int i = maxNumberOfScores - 1; i < currentNumberOfScores; i++)
            {
                this.currentScoreBoard.Records.RemoveAt(maxNumberOfScores - 1);
            }
        }

        /// <summary>
        /// Sorts the IPersonalScore items in the current instance of IScoreBoard based on the Score property.
        /// </summary>
        public void SortScoreBoard()
        {
            this.currentScoreBoard.Records = this.currentScoreBoard.Records.OrderBy(ps => ps.Score).ToList();
        }

        /// <summary>
        /// Returns the number of Score either of the last item in the current instance of IScoreBoard 
        /// or of the instance situated on the last index according the provided parameter.
        /// </summary>
        /// <param name="maxNumberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>Number of Score of the last item allowed to be in the IScoreBoard</returns>
        public int GetWorstScore(int maxNumberOfScoresInScoreBoard)
        {
            IPersonalScore lastScore;

            if (this.currentScoreBoard.Records.Count <= maxNumberOfScoresInScoreBoard)
            {
                lastScore = this.currentScoreBoard.Records[this.currentScoreBoard.Records.Count - 1];
            }
            else
            {
                lastScore = this.currentScoreBoard.Records[maxNumberOfScoresInScoreBoard - 1];
            }

            return lastScore.Score;
        }

        /// <summary>
        /// Checks whether the number of Records in the current instance of IScoreBoard
        ///  is equal or above the provided limit.
        /// </summary>
        /// <param name="numberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>True if the conditions are met.</returns>
        public bool IsFull(int numberOfScoresInScoreBoard)
        {
            var isFull = this.currentScoreBoard.Records.Count() >= numberOfScoresInScoreBoard;

            return isFull;
        }

        /// <summary>
        /// Checks whether the number of Records in the current instance of IScoreBoard
        ///  is equal to zero.
        /// </summary>
        /// <returns>True if there are no records.</returns>
        public bool IsEmpty()
        {
            var isEmpty = this.currentScoreBoard.Records.Count() == 0;

            return isEmpty;
        }

        /// <summary>
        /// Sets the collection of IPersonalScore of the current instance of IScoreBoard
        /// to a provided IList.
        /// </summary>
        /// <param name="restoredResults">An IList of IPersonalScore</param>
        public void RestoreScores(IList<IPersonalScore> restoredResults)
        {
            this.currentScoreBoard.Records = restoredResults;
        }

        /// <summary>
        /// Checks if the current player score can be submitted to the IScoreBoard on basis of the current number of items
        /// and the maximum number of items allowed and the number of the mistakes of the last IPersonalScore
        /// </summary>
        /// <param name="player">Current player</param>
        /// <param name="maxNumberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>True if the player score can be submitted to the IScoreBoard</returns>
        public bool CheckIfPlayerCanEnterHighScores(Players.Contracts.IPlayer player, int maxNumberOfScoresInScoreBoard)
        {
            bool playerCanEnterHighScores = true;

            if (this.IsFull(maxNumberOfScoresInScoreBoard))
            {
                var worstScore = this.GetWorstScore(maxNumberOfScoresInScoreBoard);
                playerCanEnterHighScores = worstScore >= player.Mistakes;

                if (playerCanEnterHighScores)
                {
                    this.RemoveLastScores(maxNumberOfScoresInScoreBoard);
                }
            }

            return playerCanEnterHighScores;
        }

        /// <summary>
        /// Gets the IPersonalScore records from the database, sorts them and compares their number with 
        /// the provided maximum number of items.
        /// </summary>
        /// <param name="maxNumberOfScoresInScoreBoard">Maximum number of items allowed in the IScoreBoard</param>
        /// <returns>IList of IPersonalScore records</returns>
        public IList<IPersonalScore> GetTopScores(int maxNumberOfScoresInScoreBoard)
        {
            DataFileManager.SingletonInstance.RestoreResults(this, Constants.DatabaseFile);
            
            this.SortScoreBoard();

            var topScores = new List<IPersonalScore>(this.currentScoreBoard.Records.Take(maxNumberOfScoresInScoreBoard));

            return topScores;
        }
    }
}