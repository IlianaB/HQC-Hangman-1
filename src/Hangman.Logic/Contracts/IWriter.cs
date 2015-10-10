// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IWriter.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Writes on a same line
        /// </summary>
        /// <param name="text">Text as a string</param>
        void Write(string text);

        /// <summary>
        /// Writes on a new line
        /// </summary>
        /// <param name="text">Text as a string</param>
        void WriteLine(string text);
    }
}
