// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IReader.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares all methods its implementation must have.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads users input.
        /// </summary>
        /// <returns>
        /// Input as a string.
        /// </returns>
        string ReadText();
    }
}
