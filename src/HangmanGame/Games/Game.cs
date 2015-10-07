using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Games;

namespace HangmanGame.HangmanGame
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
