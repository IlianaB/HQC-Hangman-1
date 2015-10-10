// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IPersonalScore.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementations must have.
    /// </summary>
    public interface IPersonalScore
    {
        /// <summary>
        /// Gets the name of the player
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the score of the player
        /// </summary>
        int Score { get; }
    }
}