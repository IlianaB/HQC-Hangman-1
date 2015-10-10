// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IGuessWord.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Words.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementation must have.
    /// </summary>
    public interface IGuessWord
    {
        string Content { get; set; }

        char[] Mask { get; set; }

        char RevealLetter();

        int GetNumberOfOccurences(char letter);
    }
}
