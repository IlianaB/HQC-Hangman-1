using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Console
{
    using System;

    public class ConsoleInputProvider : IInputProvider
    {
        public string GetPlayerName()
        {
            Console.Write(Constants.EnterNameMessage);
            string name = Console.ReadLine();

            return name;
        }

        public string ReadCommand()
        {
            Console.Write(Constants.EnterGuessMessage);
            string command = Console.ReadLine();
            string lowerCaseCommand = command.ToLower();

            return lowerCaseCommand;
        }
    }
}
