// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="PersonalScore.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.ScoreBoardServices
{
    /// <summary>
    /// Groups Player's name and mistakes into Personal score object.
    /// </summary>
    public class PersonalScore : IPersonalScore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalScore"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the player.
        /// </param>
        /// <param name="score">
        /// The score of the player.
        /// </param>
      public PersonalScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

      /// <summary>
      /// Gets the name of the player
      /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the score
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Overrides object's ToString method
        /// </summary>
        /// <returns>
        /// String representation of Personal Score.
        /// </returns>
        public override string ToString()
        {
            return this.Name + " - " + this.Score;
        }
    }
}