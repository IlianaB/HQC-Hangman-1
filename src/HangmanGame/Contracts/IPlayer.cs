namespace HangmanGame.HangmanGame.Contracts
{
    public interface IPlayer
    {
        int Mistakes { get; }
        bool HasUsedHelp { get; set; }
        void IncreaseMistakes();
        void Reset();
    }
}
