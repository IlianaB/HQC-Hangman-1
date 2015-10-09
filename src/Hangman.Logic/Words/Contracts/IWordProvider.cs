using System.Collections.Generic;

namespace Hangman.Logic.Words.Contracts
{
    public interface IWordProvider
    {
        List<string> ProvideWords();
    }
}
