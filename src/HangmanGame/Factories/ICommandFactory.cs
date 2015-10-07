using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Factories
{
    public interface ICommandFactory
    {
        ICommand GetGommand(ICommandExecutable engine, string command);
    }
}
