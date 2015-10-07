using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Console
{
    public abstract class InputProvider : IInputProvider
    {
        public abstract string ReadCommand();
    }
}
