using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;
using HangmanGame.HangmanGame.States.Activation;

namespace HangmanGame.HangmanGame.Contracts
{
    public interface ICommandExecutable
    {
        IRenderer Renderer { get; }
        GuessWord WordToGuess { get; }
        IScoreBoard ScoreBoard { get; }
        ScoreBoardService ScoreBoardService { get; }
        bool IsHelpUsed { get; set; }
        void StartGame(ActivationState activationState);
        void ResetGame();
    }
}
