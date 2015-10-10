// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="RestartCommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Reset Game command.
    /// </summary>
    public class RestartCommand : Command, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestartCommand"/> class.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        public RestartCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// It invokes the ResetGame method.
        /// </summary>
        public override void Execute()
        {
            this.Engine.ResetGame();
        }
    }
}