using HangmanGame.HangmanGame.States.Activation;

namespace HangmanGame.HangmanGame.Contracts
{
    public interface IEngine
    {
        void StartGame(ActivationState activationState);

        void ResetGame();

        void FinishGame();

        void ReactToPlayerAction(string command);
    }
}
