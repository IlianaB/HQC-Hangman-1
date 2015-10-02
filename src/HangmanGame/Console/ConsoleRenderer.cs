using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Console
{
    using System;
    using System.Collections.Generic;

    public class ConsoleRenderer : IRenderer
    {
        public void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
        {
            if (isEmptyScoreBoard)
            {
                Console.WriteLine(Constants.EmptyScoreboardMessage);
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                
                int position = 1;
                foreach (var record in records)
                {
                    Console.WriteLine(Constants.ResultsInformationMessage, position, record.Name, record.Score);
                    position++;
                }
            }
        }

        public void ShowCurrentProgress(char[] guessedLetters)
        {
            Console.WriteLine();

            Console.Write(Constants.AnnounceSecretWordMessage);

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                Console.Write("{0} ", guessedLetters[i]);
            }

            Console.WriteLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}