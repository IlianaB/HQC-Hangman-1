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

        /// <summary>
        /// Checks if the player has used the received letter.
        /// </summary>
        /// <param name="letter">
        /// The guessed letter.
        /// </param>
        /// <returns>
        /// Boolean variable indicating if the player has used this letter before or not.
        /// </returns>
        bool CheckIfLetterIsUsed(char letter);

        /// <summary>
        /// Adds a new used letter
        /// </summary>
        /// <param name="letter">
        /// The letter which is used.
        /// </param>
        void AddNewUsedLetter(char letter);
    }
}
