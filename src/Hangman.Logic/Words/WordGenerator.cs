using System;
using System.Collections.Generic;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Logic.Words
{
    /// <summary>
    /// Responsible for the generating of words to be guessed.
    /// </summary>
    public class WordGenerator : IWordGenerator
    {
        private readonly List<string> words;
        private readonly Random random;

        /// <summary>
        /// Creates a Random instance and sets it on its random field. 
        /// Receives a IWordProvider and sets it on its words field.
        /// </summary>
        /// <param name="wordProvider">
        /// The one who keeps the available words.
        /// </param>
        public WordGenerator(IWordProvider wordProvider)
        {
            this.random = new Random();
            this.words = wordProvider.ProvideWords();
        }

        /// <summary>
        /// Returns a random word from the wordprovider.
        /// </summary>
        /// <returns>
        /// A random word as a string.
        /// </returns>
        public string GetRandomWord()
        {
            int choice = this.random.Next(this.words.Count);
            string word = this.words[choice];

            return word;
        }
    }
}
