using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Commands
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
