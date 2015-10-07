﻿using System.Collections.Generic;
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
        public WPFRenderer()
            : this(new AllCapsFormatter())
        {
        }

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
            switch (mistakes)
            {
                case 1:
                    this.MainWindow.VerticalLine.Visibility = Visibility.Visible;
                    this.MainWindow.HorizontalLine.Visibility = Visibility.Visible;
                    this.MainWindow.Rope.Visibility = Visibility.Visible;
                    break;
                case 2:
                    this.MainWindow.Head.Visibility = Visibility.Visible;
                    break;
                case 3:
                    this.MainWindow.Body.Visibility = Visibility.Visible;
                    break;
                case 4:
                    this.MainWindow.LeftHand.Visibility = Visibility.Visible;
                    break;
                case 5:
                    this.MainWindow.RightHand.Visibility = Visibility.Visible;
                    break;
                case 6:
                    this.MainWindow.LeftLeg.Visibility = Visibility.Visible;
                    break;
                case 7:
                    this.MainWindow.RightLeg.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
