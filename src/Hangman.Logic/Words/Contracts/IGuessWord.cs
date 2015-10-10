// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IGuessWord.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Words.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementation must have.
    /// </summary>
    public interface IGuessWord
    {
        /// <summary>
        /// Gets or sets the content of the word.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the mask of the word.
        /// </summary>
        char[] Mask { get; set; }

        /// <summary>
        /// Reveals the first hidden letter of the GuessWord.
        /// </summary>
        /// <returns>
        /// Single letter as a char.
        /// </returns>
        char RevealLetter();

        /// <summary>
        /// Counts the number of occurrences of the received letter in the GuessWord.
        /// </summary>
        /// <param name="letter">
        /// The letter to be searched in the word.
        /// </param>
        /// <returns>
        /// The number of occurrences of the received letter in the GuessWord.
        /// </returns>
        int GetNumberOfOccurences(char letter);
    }
}
