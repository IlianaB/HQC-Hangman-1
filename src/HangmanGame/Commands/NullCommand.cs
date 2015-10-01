using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Commands
{
    public class NullCommand : Command, ICommand
    {
        public NullCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
        }
    }
}
