using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Formatters;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.UIInteractors;

namespace Hangman.Console.UI.Console
{
    using System;
    using System.Collections.Generic;

    public class ConsoleRenderer : Renderer, IRenderer
    {
        public ConsoleRenderer()
            : this(new CapitalizeFormatter(), new Writer())
        {
        }

        public ConsoleRenderer(IResultFormatter formatter, IWriter writer)
            : base(formatter, writer)
        {
        }

        public override void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
        {
            if (isEmptyScoreBoard)
            {
                this.Writer.WriteLine(Constants.EmptyScoreboardMessage);
            }
            else
            {
                this.Writer.WriteLine("Scoreboard:");

                int position = 1;
                foreach (var record in records)
                {
                    this.Writer.WriteLine(position + ". " + this.Formatter.Format(record));
                    position++;
                }
            }
        }

        public override void ShowCurrentProgress(char[] guessedLetters)
        {
            this.Writer.WriteLine(string.Empty);

            this.Writer.Write(Constants.AnnounceSecretWordMessage);

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                this.Writer.Write(string.Format("{0} ", guessedLetters[i]));
            }

            this.Writer.WriteLine(string.Empty);
        }

        public override void ShowMessage(string message)
        {
            this.Writer.WriteLine(message);
        }

        public override void DrawHangman(int mistakes)
        {
            switch (mistakes)
            {
                case 1:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;

                case 2:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;
                case 3:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |    \\|");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;
                case 4:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |    \\|/");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;
                case 5:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |    \\|/");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;
                case 6:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |    \\|/");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |    /");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;
                case 7:
                    this.Writer.WriteLine("   _____");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |     O");
                    this.Writer.WriteLine("  |    \\|/");
                    this.Writer.WriteLine("  |     |");
                    this.Writer.WriteLine("  |    / \\");
                    this.Writer.WriteLine("  |");
                    this.Writer.WriteLine("__|__");
                    break;
            }
        }
    }
}