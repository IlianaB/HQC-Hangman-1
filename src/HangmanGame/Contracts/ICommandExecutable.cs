using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Contracts
{
    public interface ICommandExecutable
    {
        IRenderer Renderer { get; }

        GuessWord WordToGuess { get; }

        IScoreBoardService ScoreBoardService { get; }

        IPlayer Player { get; }

        void StartGame();

        void ResetGame();
    }
}
