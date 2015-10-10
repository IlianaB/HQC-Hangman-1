using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A Null command with default behaviour.
    /// </summary>
    public class NullCommand : Command, ICommand
    {
        public NullCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Renderer.ShowMessage(Constants.IncorrectCommandMessage);
        }
    }
}