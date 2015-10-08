using Hangman.Logic.Contracts;

namespace Hangman.Console.UI.Console
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
