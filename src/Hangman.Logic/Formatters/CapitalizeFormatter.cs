// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="CapitalizeFormatter.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Formatters
{
    /// <summary>
    /// Implementation of IResultFormatter.
    /// It is responsible for the formatting of Players' results.
    /// Part of the Bridge Pattern.
    /// </summary>
    public class CapitalizeFormatter : IResultFormatter
    {
        /// <summary>
        /// It formats the players score, capitalizing only the first letter of Player's name.
        /// </summary>
        /// <param name="record">
        /// Player's score.
        /// </param>
        /// <returns>
        /// Player's score as a string, with only the first letter of Player's name capitalized.
        /// </returns>
        public string Format(IPersonalScore record)
        {
            string playerName = this.CapitalizeFirstLetter(record.Name);
            string result = string.Format("{0} ---> {1} mistake(s)!", playerName, record.Score);

            return result;
        }

        /// <summary>
        /// Returns the received word with a Capitalized first letter.
        /// </summary>
        /// <param name="word">
        /// Word as a string.
        /// </param>
        /// <returns>
        /// Word with a Capitalized first letter.
        /// </returns>
        private string CapitalizeFirstLetter(string word)
        {
            string result = char.ToUpper(word[0]) + word.Substring(1).ToLower();

            return result;
        }
    }
}
