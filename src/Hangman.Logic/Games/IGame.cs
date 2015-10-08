using Hangman.Logic.Engines;

namespace Hangman.Logic.Games
{
    public interface IGame
    {
        IEngine Engine { get; set; }

        void Initialize();

        void Start();
    }
}
