// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="IGame.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Engines;

namespace Hangman.Logic.Games
{
    /// <summary>
    /// Declares all methods and properties its implementations must have.
    /// </summary>
    public interface IGame
    {
        IEngine Engine { get; set; }

        /// <summary>
        /// Initializes all GameEngine dependencies at sets its own property GameEngine.
        /// Hides the complicate logic of all dependencies initialization.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Starts a game.
        /// </summary>
        void Start();
    }
}
