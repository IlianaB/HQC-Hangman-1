using System;
using System.Collections.Generic;

namespace Hangman.Logic.Common
{
    public class WordGenerator : IWordGenerator
    {
        private readonly List<string> words;
        private readonly Random random;

        public WordGenerator(IWordProvider wordProvider)
        {
            this.random = new Random();
            this.words = wordProvider.ProvideWords();
        }

        public string GetRandomWord()
        {
            int choice = this.random.Next(this.words.Count);
            string word = this.words[choice];

            return word;
        }
    }
}
