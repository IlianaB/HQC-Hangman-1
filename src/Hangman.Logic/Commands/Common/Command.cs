using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands.Common
{
    public abstract class Command : ICommand
    {
        protected Command(ICommandExecutable engine)
        {
            this.Engine = engine;
        }

        protected ICommandExecutable Engine { get; set; }

        public abstract void Execute();
    }
}
