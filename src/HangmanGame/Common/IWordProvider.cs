using System.Collections.Generic;

namespace HangmanGame.HangmanGame.Common
{
    public interface IWordProvider
    {
        List<string> ProvideWords();
    }
}
