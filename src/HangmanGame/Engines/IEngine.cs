using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Engines
{
    public interface IEngine
    {
        void StartGame();

        void ResetGame();

        void FinishGame();

        void ReactToPlayerAction(string command);

        bool CheckWinningCondition();

        bool CheckGameOverCondition();

        IRenderer Renderer { get; }

        GuessWord WordToGuess { get; }

        IPlayer Player { get; }

    }
}