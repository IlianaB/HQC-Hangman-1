using System.Collections.Generic;
using System.Text;
using System.Windows;

using HangmanGame.HangmanGame;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGameWPF
{
    public class WPFRenderer : IRenderer
    {

        public MainWindow MainWindow { get; set; }

        public void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
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
                    string recordInfo = string.Format(Constants.ResultsInformationMessage, position, record.Name, record.Score);
                    result.AppendLine(recordInfo);
                    position++;
                }
            }

            this.MainWindow.Results.Content = result.ToString();
        }

        public void ShowCurrentProgress(char[] guessedLetters)
        {
            this.MainWindow.SecretWord.Content = string.Join("  ", guessedLetters);
        }

        public void ShowMessage(string message)
        {
            this.MainWindow.Messages.Content = message;
        }

        public void DrawHangman(int mistakes)
        {
            //Not Implemented
        }
    }
}
