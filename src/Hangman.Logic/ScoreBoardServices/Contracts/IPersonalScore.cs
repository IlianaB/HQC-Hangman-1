namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    public interface IPersonalScore
    {
        string Name { get; }

        int Score { get; }
    }
}