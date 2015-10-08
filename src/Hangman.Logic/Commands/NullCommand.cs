using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
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
