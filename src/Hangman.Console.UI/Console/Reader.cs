using Hangman.Logic.Contracts;

namespace Hangman.Console.UI.Console
{
    using System;

    public class Reader : IReader
    {
        public string ReadText()
        {
            var line = Console.ReadLine();
            return line;
        }
    }
}
