using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Logic.Contracts
{
    public interface ICommandExecutable
    {
        IRenderer Renderer { get; }

        IGuessWord WordToGuess { get; }

        IScoreBoardService ScoreBoardService { get; }

        IPlayer Player { get; }

        void StartGame();

        void ResetGame();
    }
}
