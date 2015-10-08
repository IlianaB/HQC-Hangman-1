using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    public class RestartCommand : Command, ICommand
    {
        public RestartCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.ResetGame();
        }
    }
}