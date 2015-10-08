using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Factories
{
    public interface ICommandFactory
    {
        ICommand GetGommand(ICommandExecutable engine, string command);
    }
}
