using HangmanGame.HangmanGame.Engines;

namespace HangmanGame.HangmanGame.Games
{
    public interface IGame
    {
        IEngine Engine { get; set; }

        void Initialize();

        void Start();
    }
}
