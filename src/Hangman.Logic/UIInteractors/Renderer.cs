using Hangman.Logic.Contracts;
using Hangman.Logic.Formatters;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.UIInteractors
{
    using System.Collections.Generic;

    public abstract class Renderer : IRenderer
    {
        protected readonly IResultFormatter Formatter;
        protected IWriter Writer;

        protected Renderer(IResultFormatter formatter, IWriter writer)
        {
            this.Formatter = formatter;
            this.Writer = writer;
        }

        public abstract void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records);

        public abstract void ShowCurrentProgress(char[] guessedLetters);

        public abstract void ShowMessage(string message);

        public abstract void DrawHangman(int mistakes);
    }
}
