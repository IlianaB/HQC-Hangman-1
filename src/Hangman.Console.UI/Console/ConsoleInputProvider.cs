using Hangman.Logic.Contracts;

namespace Hangman.Console.UI.Console
{
    public class ConsoleInputProvider : IInputProvider
    {
        private readonly IReader reader;

        public ConsoleInputProvider()
            : this(new Reader())
        {
        }

        public ConsoleInputProvider(IReader reader)
        {
            this.reader = reader;
        }

        public string ReadCommand()
        {
            string command = this.reader.ReadText();
            string lowerCaseCommand = command.ToLower();

            return lowerCaseCommand;
        }
    }
}
