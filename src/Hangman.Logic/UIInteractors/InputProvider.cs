// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="InputProvider.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Contracts;

namespace Hangman.Logic.UIInteractors
{
    /// <summary>
    /// Responsible for taking the input of the user.
    /// </summary>
    public abstract class InputProvider : IInputProvider
    {
        /// <summary>
        /// Reads command from the UI.
        /// </summary>
        /// <returns>
        /// The read command as a string.
        /// </returns>
        public abstract string ReadCommand();
    }
}
