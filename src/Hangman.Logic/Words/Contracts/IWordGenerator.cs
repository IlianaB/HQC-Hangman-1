// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IWordgenerator.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Words.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IWordGenerator
    {
        /// <summary>
        /// Returns a random word from the Word Provider.
        /// </summary>
        /// <returns>
        /// A random word as a string.
        /// </returns>
        string GetRandomWord();
    }
}