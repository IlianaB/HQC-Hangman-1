using System.Collections.Generic;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Contracts
{
    public interface IRenderer
    {
        void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);

        void ShowCurrentProgress(char[] guessedLetters);

        void ShowMessage(string message);

        void DrawHangman(int mistakes);
    }
}
