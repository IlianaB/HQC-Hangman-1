using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Contracts
{
    public interface ICommandExecutable
    {
        IRenderer Renderer { get; }

        GuessWord WordToGuess { get; }

        IScoreBoard ScoreBoard { get; }

        ScoreBoardService ScoreBoardService { get; }

        IPlayer Player { get; }

        void StartGame();

        void ResetGame();
    }
}
