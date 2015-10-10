// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="GuessWord.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

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
        /// Initializes a new instance of the <see cref="GuessWord"/> class.
        /// - Content which is the same as the received string. 
        /// - Mask - char[] representation of the Content, filled with the Constant char for the mask.
        /// </summary>
        /// <param name="word">
        /// Word as a string.
        /// </param>
        public GuessWord(string word)
        {
            this.Content = word;
            this.Mask = this.GetMask(word);
        }

        /// <summary>
        /// Gets or sets the content of the word.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the mask of the word.
        /// </summary>
        public char[] Mask { get; set; }

        /// <summary>
        /// Reveals the first hidden letter of the GuessWord.
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

                this.ConvertAMaskSymboleIntoLetter(i, this.Content[i]);
                revealedLetter = this.Content[i];
                break;
            }

            return revealedLetter;
        }

        /// <summary>
        /// Counts the number of occurrences of the received letter in the GuessWord.
        /// </summary>
        /// <param name="letter">
        /// The letter to be searched in the word.
        /// </param>
        /// <returns>
        /// The number of occurrences of the received letter in the GuessWord.
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

                this.ConvertAMaskSymboleIntoLetter(i, letter);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Produces a char array containing the mask symbol, replacing all letters of the received word.
        /// </summary>
        /// <param name="word">
        /// Word as a string.
        /// </param>
        /// <returns>
        /// Char array containing the mask symbol, replacing all letters of the received word.
        /// </returns>
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

        /// <summary>
        /// Converts mask symbol into letter.
        /// </summary>
        /// <param name="index">
        /// Index of the mask symbol to be changed.
        /// </param>
        /// <param name="letter">
        /// Letter to be put on the place of the converted mask symbol.
        /// </param>
        private void ConvertAMaskSymboleIntoLetter(int index, char letter)
        {
            this.Mask[index] = letter;
        }
    }
}
