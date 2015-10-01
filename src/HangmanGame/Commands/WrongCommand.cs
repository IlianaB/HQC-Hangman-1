using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Commands
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
