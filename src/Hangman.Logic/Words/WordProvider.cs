using System.Collections.Generic;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Logic.Words
{
    public class WordProvider : IWordProvider
    {
        /// <summary>
        /// Keeps the available words to be guessed.
        /// </summary>
        /// <returns>
        /// A single word to be guessed.
        /// </returns>
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
