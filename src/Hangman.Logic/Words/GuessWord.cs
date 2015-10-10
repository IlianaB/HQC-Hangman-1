using Hangman.Logic.Common;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Logic.Words
{
    /// <summary>
    /// Creates and operates with the word which should be guessed by the Player.
    /// </summary>
    public class GuessWord : IGuessWord
    {
        /// <summary>
        /// Instancietes GuessWord with:
        /// - Content which is the same as the received string, 
        /// - Mask - char[] representation of the Content, filled with the Constant char for the mask
        /// </summary>
        /// <param name="word"></param>
        public GuessWord(string word)
        {
            this.Content = word;
            this.Mask = this.GetMask(word);
        }

        public string Content { get; set; }

        public char[] Mask { get; set; }

        /// <summary>
        /// Reveals the first hidden letter of the GuessWord
        /// </summary>
        /// <returns>
        /// Single letter as a char.
        /// </returns>
        public char RevealLetter()
        {
            char revealedLetter = char.MinValue;

            for (int i = 0; i < this.Mask.Length; i++)
            {
                if (this.Mask[i] != Constants.WordMaskChar)
                {
                    continue;
                }

                ConvertAMaskSymboleIntoLetter(i, this.Content[i]);
                revealedLetter = this.Content[i];
                break;
            }

            return revealedLetter;
        }

        /// <summary>
        /// Counts the number of occurences of the received letter in the GuessWord.
        /// </summary>
        /// <param name="letter">
        /// The letter to be searched in the word.
        /// </param>
        /// <returns>
        /// The number of occurences of the received letter in the GuessWord.
        /// </returns>
        public int GetNumberOfOccurences(char letter)
        {
            int count = 0;

            for (int i = 0; i < this.Content.Length; i++)
            {
                if (this.Content[i] != letter)
                {
                    continue;
                }

                ConvertAMaskSymboleIntoLetter(i, letter);
                count++;
            }

            return count;
        }

        private char[] GetMask(string word)
        {
            int wordLength = word.Length;
            char[] letters = new char[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                letters[i] = Constants.WordMaskChar;
            }

            return letters;
        }

        private void ConvertAMaskSymboleIntoLetter(int index, char letter)
        {
            this.Mask[index] = letter;
        }
    }
}
