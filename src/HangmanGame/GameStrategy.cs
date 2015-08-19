namespace HangmanGame.HangmanGame
{
    using System;

    public class GameStrategy
    {
        // besenicata e egati tupata igra! ujasssssssssssss, spasete me ot besiloto!

        private string wordToGuess;
        private bool helpUsed;
        public GameStrategy()
        {
            this.ReSet();
        }

        public char[] GuessedLetters { get; set; }


        public void ReSet()
        {
            this.wordToGuess = this.IzberiRandomWord();
            this.GuessedLetters = new char[this.wordToGuess.Length];




            for (int i = 0; i < this.wordToGuess.Length; i++)
            {
                this.GuessedLetters[i] = '_';
            }

            this.helpUsed = false;
        }

        public bool HelpUsed
        {
            get { return this.helpUsed; }
        }
        public char RevealALetter()
        {
            char toReturnt = char.MinValue;
            for (int i = 0; i < this.GuessedLetters.Length; i++)
            {
                if (this.GuessedLetters[i] == '_')
                {
                    this.GuessedLetters[i] = this.wordToGuess[i];
                    toReturnt = this.wordToGuess[i];
                    this.helpUsed = true;
                    break;
                }
            }
            return toReturnt;
        }


        public int NumberOccuranceOfLetter(char letter)
        {
            int count = 0;
            for (int i = 0; i < this.wordToGuess.Length; i++)
            {
                if (this.wordToGuess[i] == letter)
                {
                    this.GuessedLetters[i] = letter;
                    count++;
                }
            }

            return count;
        }

        public bool isOver()
        {
            for (int i = 0; i < this.GuessedLetters.Length; i++)
            {
                if (this.GuessedLetters[i] == '_')
                {


                    return false;
                }
            }
            return true;
        }


        private string[] words = {"computer", "programmer", "software", "debugger","compiler", "developer", "algorithm",
                                      "array", "method", "variable" };

        private Random randomGenerator = new Random();

        private string IzberiRandomWord()
        {




            int choice = this.randomGenerator.Next(this.words.Length);

            return this.words[choice];
        }


    }
}
