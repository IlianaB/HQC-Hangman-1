namespace HangmanGame.HangmanGame.Contracts
{
    public interface IInputProvider
    {
        string GetPlayerName();

        string ReadCommand();
    }
}
