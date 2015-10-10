// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="Game.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using Hangman.Logic.Engines;

namespace Hangman.Logic.Games
{
    /// <summary>
    /// Facade Design Pattern.
    /// It is responsible for initializing all GameEngine dependencies and starts the game.
    /// </summary>
    public abstract class Game : IGame
    {
        /// <summary>
        /// Gets or sets an implementation of IEngine
        /// </summary>
        public IEngine Engine { get; set; }

        /// <summary>
        /// Initializes all GameEngine dependencies at sets its own property GameEngine.
        /// Hides the complicate logic of all dependencies initialization.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Starts a game.
        /// </summary>
        public void Start()
        {
            this.Engine.StartGame();
        }
    }
}
