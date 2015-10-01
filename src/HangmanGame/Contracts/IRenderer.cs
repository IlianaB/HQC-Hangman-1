using System.Collections.Generic;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Contracts
{
    public interface IRenderer
    {
        void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);
        void ShowCurrentProgress(char[] guessedLetters);
        void ShowMessage(string message);
    }
}
