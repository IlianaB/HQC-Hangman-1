// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ICommandExecutable.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Logic.Contracts
{
    /// <summary>
    /// Declares the properties and methods all its implementation must have.
    /// </summary>
    public interface ICommandExecutable
    {
        /// <summary>
        /// Gets an implementation of IRenderer
        /// </summary>
        IRenderer Renderer { get; }

        /// <summary>
        /// Gets an implementation of IGuessWord
        /// </summary>
        IGuessWord WordToGuess { get; }

        /// <summary>
        /// Gets an implementation of IScoreBoardService
        /// </summary>
        IScoreBoardService ScoreBoardService { get; }

        /// <summary>
        /// Gets an implementation of IPlayer
        /// </summary>
        IPlayer Player { get; }

        /// <summary>
        /// Starts a game.
        /// </summary>
        void StartGame();

        /// <summary>
        /// Resets a game.
        /// </summary>
        void ResetGame();
    }
}
