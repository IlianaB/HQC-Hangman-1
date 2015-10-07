using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Console
{
    using System;

    public class ConsoleInputProvider : IInputProvider
    {
        public string ReadCommand()
        {
            string command = Console.ReadLine();
            string lowerCaseCommand = command.ToLower();

            return lowerCaseCommand;
        }
    }
}
