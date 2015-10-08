using Hangman.Logic.Engines;

namespace Hangman.Logic.Games
{
    public abstract class Game : IGame
    {
        public IEngine Engine { get; set; }

        public virtual void Initialize()
        {
        }

        public void Start()
        {
            this.Engine.StartGame();
        }
    }
}
