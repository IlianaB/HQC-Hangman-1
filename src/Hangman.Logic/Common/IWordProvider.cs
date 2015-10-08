using System.Collections.Generic;

namespace Hangman.Logic.Common
{
    public interface IWordProvider
    {
        List<string> ProvideWords();
    }
}
