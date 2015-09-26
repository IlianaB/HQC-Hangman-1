using HangmanGame.HangmanGame.Commands;
using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Factories
{
    public class CommandFactory
    {
        public Command GetCommand(GameEngine engine, string command)
        {

            switch (command)
            {
                case "top":
                    {
                        return new TopCommand(engine);
                    }
                case "help":
                    {
                        return new HelpCommand(engine);
                    }
                case "restart":
                    {
                        return new RestartCommand(engine);
                    }
                case "exit":
                    {
                        return new ExitCommand(engine);
                    }
                default:
                    {
                        return new WrongCommand(engine);
                    }
            }
        }
    }
}
