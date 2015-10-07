using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame
{
    public abstract class Game
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
