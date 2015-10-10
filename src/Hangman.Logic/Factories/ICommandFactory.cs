// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ICommandFactory.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Factories
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates a concrete implementation of ICommand depending on the received string.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        /// <param name="command">
        /// The command as a string.
        /// </param>
        /// <returns>
        /// The concrete command.
        /// </returns>
        ICommand GetGommand(ICommandExecutable engine, string command);
    }
}
