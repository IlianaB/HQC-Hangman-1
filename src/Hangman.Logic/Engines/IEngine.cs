// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IEngine.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Contracts;
using Hangman.Logic.Players.Contracts;

namespace Hangman.Logic.Engines
{
    /// <summary>
    /// Declares all methods and properties its implementation must have.
    /// </summary>
    public interface IEngine
    {
        IRenderer Renderer { get; }

        IPlayer Player { get; }

        /// <summary>
        /// Creates a setup for the current game:
        /// Initializes a new WordToGuess, prints welcome message and invokes the Play method.
        /// </summary>
        void StartGame();

        /// <summary>
        /// Invokes the Player's Reset method to ensure he starts the new game with 0 mistakes and invokes StartGame method.
        /// </summary>
        void ResetGame();

        /// <summary>
        /// Ends a won game. 
        /// The method checks if the Player has used help and if he does not - it checks if the Player can enter High Scores and processes his score.
        /// </summary>
        void EndWonGame();

        /// <summary>
        /// Shows Game Over message and invokes RestartGame method.
        /// </summary>
        void EndLostGame();

        /// <summary>
        /// Reacts to player action, received as a string command.
        /// If the command has length = 1, the method invokes ExecuteLetterGuess method.
        /// If the command length is > 1, the method gets a command from the Command Factory (using the input parameters) and invokes ExecuteCommand method.
        /// </summary>
        /// <param name="command">Command as a string, read by the Input provider.</param>
        void ReactToPlayerAction(string command);

        /// <summary>
        /// Checks if the Player has guessed the secret word.
        /// </summary>
        /// <returns>
        /// Boolean variable saying if the Player has guessed the secret word or not.
        /// </returns>
        bool CheckWinningCondition();

        /// <summary>
        /// Checks if the Player has made more mistakes than the maximum possible mistakes.
        /// </summary>
        /// <returns>
        /// Boolean variable saying if the game is over or not. 
        /// </returns>
        bool CheckGameOverCondition();
    }
}