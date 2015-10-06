using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Console
{
    using System;

    public class ConsoleInputProvider : InputProvider, IInputProvider
    {
        public override string GetPlayerName()
        {
            Console.Write(Constants.EnterNameMessage);
            string name = Console.ReadLine();

            return name;
        }

        public override string ReadCommand()
        {
            Console.Write(Constants.EnterGuessMessage);
            string command = Console.ReadLine();
            string lowerCaseCommand = command.ToLower();

            return lowerCaseCommand;
        }
    }
}
