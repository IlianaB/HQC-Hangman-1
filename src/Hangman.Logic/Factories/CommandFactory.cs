using Hangman.Logic.Commands;
using Hangman.Logic.Commands.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetGommand(ICommandExecutable engine, string command)
        {
            switch (command)
            {
                case "start": return new StartCommand(engine);
                case "top": return new TopCommand(engine);
                case "help": return new HelpCommand(engine);
                case "restart": return new RestartCommand(engine);
                case "exit": return new ExitCommand(engine);
                default: return new NullCommand(engine);
            }
        }
    }
}
