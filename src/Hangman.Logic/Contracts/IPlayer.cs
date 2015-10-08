namespace Hangman.Logic.Contracts
{
    public interface IPlayer
    {
        string Name { get; set; }

        int Mistakes { get; }

        bool HasUsedHelp { get; set; }

        void IncreaseMistakes();

        void Reset();
    }
}
