using HangmanGame.HangmanGame.Commands;
using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Factories
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
                case null: return new NullCommand(engine);
                default: return new WrongCommand(engine);
            }
        }
    }
}
