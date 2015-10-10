// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="StartCommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Start command.
    /// </summary>
    public class StartCommand : Command, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartCommand"/> class.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        public StartCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        public override void Execute()
        {
            this.Engine.StartGame();
        }
    }
}
