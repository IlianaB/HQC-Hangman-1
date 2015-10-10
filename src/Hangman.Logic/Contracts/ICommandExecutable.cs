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
        IRenderer Renderer { get; }

        IGuessWord WordToGuess { get; }

        IScoreBoardService ScoreBoardService { get; }

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
