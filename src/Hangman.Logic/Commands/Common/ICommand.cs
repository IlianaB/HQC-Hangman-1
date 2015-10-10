// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ICommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Commands.Common
{
    /// <summary>
    /// Declares the method that all different implementations (commands) must have - Execute.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command - the implementation vary.
        /// </summary>
        void Execute();
    }
}
