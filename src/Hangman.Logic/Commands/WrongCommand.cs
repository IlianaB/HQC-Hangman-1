using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    public class WrongCommand : Command, ICommand
    {
        public WrongCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Renderer.ShowMessage(Constants.IncorrectCommandMessage);
        }
    }
}
