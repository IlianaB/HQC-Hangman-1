using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Reset Game command.
    /// </summary>
    public class RestartCommand : Command, ICommand
    {
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