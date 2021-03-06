﻿// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="AllCapsFormatter.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Formatters
{
    /// <summary>
    /// Implementation of IResultFormatter.
    /// It is responsible for the formatting of Players' results.
    /// Part of the Bridge Pattern.
    /// </summary>
    public class AllCapsFormatter : IResultFormatter
    {
        /// <summary>
        /// It formats the players score with all letters in Uppercase.
        /// </summary>
        /// <param name="record">
        /// Player's score.
        /// </param>
        /// <returns>
        /// Player's score as string, formatted with all letters in Uppercase.
        /// </returns>
        public string Format(IPersonalScore record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record", "Incorrect IPersonalScore");
            }

            string playerName = this.CapitalizeAllLetters(record.Name);
            string result = string.Format("{0} ---> {1} MISTAKE(S)!", playerName, record.Score);

            return result;
        }

        /// <summary>
        /// Returns the received word with all letters in Uppercase.
        /// </summary>
        /// <param name="word">
        /// Word as a string.
        /// </param>
        /// <returns>
        /// Word with letters in Uppercase.
        /// </returns>
        private string CapitalizeAllLetters(string word)
        {
            string result = word.ToUpper();

            return result;
        }
    }
}
