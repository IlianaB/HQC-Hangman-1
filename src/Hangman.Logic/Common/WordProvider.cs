using System.Collections.Generic;

namespace Hangman.Logic.Common
{
    public class WordProvider : IWordProvider
    {
        public List<string> ProvideWords()
        {
            List<string> words = new List<string>()
            {
                "computer", 
                "programmer", 
                "software", 
                "debugger", 
                "compiler", 
                "developer", 
                "algorithm", 
                "array", 
                "method", 
                "variable"
            };

            return words;
        }
    }
}
