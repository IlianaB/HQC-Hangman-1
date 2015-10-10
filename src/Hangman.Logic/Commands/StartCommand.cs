using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Start command.
    /// </summary>
    public class StartCommand : Command, ICommand
    {
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
