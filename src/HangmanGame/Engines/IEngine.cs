using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Engines
{
    public interface IEngine
    {
        IRenderer Renderer { get; }

        IPlayer Player { get; }

        void StartGame();

        void ResetGame();

        void EndWonGame();

        void EndLostGame();

        void ReactToPlayerAction(string command);

        bool CheckWinningCondition();

        bool CheckGameOverCondition();
    }
}