namespace HangmanGame.HangmanGame.ScoreBoardServices.Contracts
{
    public interface IScoreBoardService
    {
        void AddNewScore(IPersonalScore record);
        void SortScoreBoard();
        int GetWorstScoreEntry(int position);
        bool IsFull(int numberOfScoresInScoreBoard);
        bool IsEmpty();
        void ReSet();
    }
}