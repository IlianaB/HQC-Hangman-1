// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IPlayer.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Players.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets the name of the player
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the mistakes of the player
        /// </summary>
        int Mistakes { get; }

        /// <summary>
        /// Gets or sets a value indicating whether player has used help or not
        /// </summary>
        bool HasUsedHelp { get; set; }

        /// <summary>
        /// Increase Player's mistakes with one.
        /// </summary>
        void IncreaseMistakes();

        /// <summary>
        /// Reset Player's mistakes to 0 and sets its property HasUsedHelp to false.
        /// </summary>
        void Reset();
    }
}
