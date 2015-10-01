using System;

namespace HangmanGame.HangmanGame.Common
{
    public class WordGenerator
    {
        private readonly string[] words =
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

        private readonly Random random;

        public WordGenerator()
        {
            this.random = new Random();
        }

        public string GetRandomWord()
        {
            int choice = this.random.Next(this.words.Length);
            string word = this.words[choice];

            return word;
        }
    }
}
