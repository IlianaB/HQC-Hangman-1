using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Console
{
    using System.Collections.Generic;

    public abstract class Renderer : IRenderer
    {
        public abstract void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);

        public abstract void ShowCurrentProgress(char[] guessedLetters);

        public abstract void ShowMessage(string message);

        public abstract void DrawHangman(int mistakes);
    }
}
