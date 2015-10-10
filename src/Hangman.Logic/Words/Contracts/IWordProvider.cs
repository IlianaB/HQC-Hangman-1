// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IWordProvider.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System.Collections.Generic;

namespace Hangman.Logic.Words.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IWordProvider
    {
        /// <summary>
        /// Keeps the available words to be guessed.
        /// </summary>
        /// <returns>
        /// A single word to be guessed.
        /// </returns>
        List<string> ProvideWords();
    }
}
