// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="Player.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Players.Contracts;

namespace Hangman.Logic.Players
{
    /// <summary>
    /// Responsible for all the information about Players.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Initialize the current player with an empty string name and 0 mistakes as a start value.
        /// </summary>
        public Player()
        {
            this.Name = string.Empty;
            this.Mistakes = 0;
            this.HasUsedHelp = false;
        }

        /// <summary>
        /// Gets or sets players name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets players mistakes
        /// </summary>
        public int Mistakes { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether player has used help or not
        /// </summary>
        public bool HasUsedHelp { get; set; }

        /// <summary>
        /// Increase Player's mistakes with one.
        /// </summary>
        public void IncreaseMistakes()
        {
            this.Mistakes++;
        }

        /// <summary>
        /// Reset Player's mistakes to 0 and sets its property HasUsedHelp to false.
        /// </summary>
        public void Reset()
        {
            this.Mistakes = 0;
            this.HasUsedHelp = false;
        }
    }
}
