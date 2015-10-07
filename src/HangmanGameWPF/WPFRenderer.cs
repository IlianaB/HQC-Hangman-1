using System.Collections.Generic;
using System.Text;
using System.Windows;

using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Console;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Formatters;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGameWPF
{
    public class WPFRenderer : Renderer, IRenderer
    {
        public WPFRenderer(IResultFormatter formatter)
            : base(formatter)
        {
        }

        public MainWindow MainWindow { get; set; }

        public override void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
        {
            this.MainWindow.Results.Visibility = Visibility.Visible;

            var result = new StringBuilder();

            if (isEmptyScoreBoard)
            {
                result.Append(Constants.EmptyScoreboardMessage);
            }
            else
            {
                result.AppendLine("Scoreboard:");

                int position = 1;
                foreach (var record in records)
                {
                    string recordInfo = position + ". " + this.Formatter.Format(record);
                    result.AppendLine(recordInfo);
                    position++;
                }
            }

            this.MainWindow.Results.Content = result.ToString();
        }

        public override void ShowCurrentProgress(char[] guessedLetters)
        {
            this.MainWindow.SecretWord.Content = string.Join("  ", guessedLetters);
        }

        public override void ShowMessage(string message)
        {
            this.MainWindow.Messages.Content = message;
        }

        public override void DrawHangman(int mistakes)
        {
            //Not Implemented
        }
    }
}
