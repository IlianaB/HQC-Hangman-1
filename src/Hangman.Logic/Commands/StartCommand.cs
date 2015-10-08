using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    public class StartCommand : Command, ICommand
    {
        public StartCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.StartGame();
        }
    }
}
