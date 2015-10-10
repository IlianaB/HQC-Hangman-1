// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="Command.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands.Common
{
    /// <summary>
    /// Abstract Command class
    /// </summary>
    public abstract class Command : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        protected Command(ICommandExecutable engine)
        {
            this.Engine = engine;
        }
        
        /// <summary>
        /// Gets or sets an implementation of ICommandExecutable
        /// </summary>
        protected ICommandExecutable Engine { get; set; }
        
        /// <summary>
        /// Executes the command - the implementation vary.
        /// </summary>
        public abstract void Execute();
    }
}
