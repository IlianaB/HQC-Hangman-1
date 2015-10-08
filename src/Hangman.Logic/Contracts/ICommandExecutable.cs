using Hangman.Logic.Common;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Contracts
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
