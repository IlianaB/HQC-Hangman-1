﻿// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="WordGenerator.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

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
        /// <summary>
        /// Collection containing all available words to be guessed.
        /// </summary>
        private readonly List<string> words;

        /// <summary>
        /// Instance of .net Random class
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordGenerator"/> class.
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
        /// Returns a random word from the Word Provider.
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
