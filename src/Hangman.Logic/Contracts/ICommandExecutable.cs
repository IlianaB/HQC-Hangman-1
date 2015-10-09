using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words;

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
