// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="NullCommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A Null command with default behavior.
    /// </summary>
    public class NullCommand : Command, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullCommand"/> class.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        public NullCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Default command - shows message for incorrect command.
        /// </summary>
        public override void Execute()
        {
            this.Engine.Renderer.ShowMessage(Constants.IncorrectCommandMessage);
        }
    }
}