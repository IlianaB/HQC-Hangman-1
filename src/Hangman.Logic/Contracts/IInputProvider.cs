// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IInputProvider.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares all methods its implementation must have.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Reads a command.
        /// </summary>
        /// <returns>
        /// A command as a string.
        /// </returns>
        string ReadCommand();
    }
}