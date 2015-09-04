namespace HangmanGame.HangmanGame
{
    using System;
    using System.Linq;

    public class GameStrategy
    {
        private readonly Random randomGenerator = new Random();
        private readonly string[] words = { "computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };

        private string wordToGuess;
        private bool helpUsed;
        
        public GameStrategy()
        {
            this.ReSet();
        }

        public char[] GuessedLetters { get; set; }

        public bool HelpUsed
        {
            get
            {
                return this.helpUsed;
            }
        }

        public void ReSet()
        {
            this.wordToGuess = this.ChooseRandomWord();
            this.GuessedLetters = new char[this.wordToGuess.Length];

            for (int i = 0; i < this.wordToGuess.Length; i++)
            {
                this.GuessedLetters[i] = '_';
            }

            this.helpUsed = false;
        }

        public char RevealALetter()
        {
            char toReturnt = char.MinValue;
           
            for (int i = 0; i < this.GuessedLetters.Length; i++)
            {
                if (this.GuessedLetters[i] != '_')
                {
                    continue;
                }

                this.GuessedLetters[i] = this.wordToGuess[i];
                toReturnt = this.wordToGuess[i];
                this.helpUsed = true;
                break;
            }

            return toReturnt;
        }

        public int NumberOccuranceOfLetter(char letter)
        {
            int count = 0;

            for (int i = 0; i < this.wordToGuess.Length; i++)
            {
                if (this.wordToGuess[i] != letter)
                {
                    continue;
                }

                this.GuessedLetters[i] = letter;
                count++;
            }

            return count;
        }

        public bool IsOver()
        {
            return this.GuessedLetters.All(t => t != '_');
        }

        private string ChooseRandomWord()
        {
            int choice = this.randomGenerator.Next(this.words.Length);
            return this.words[choice];
        }
    }
}
