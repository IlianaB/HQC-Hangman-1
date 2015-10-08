using Hangman.Logic.Contracts;

namespace Hangman.Logic.UIInteractors
{
    public abstract class InputProvider : IInputProvider
    {
        public abstract string ReadCommand();
    }
}
