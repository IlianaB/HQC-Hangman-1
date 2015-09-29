using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame
{
    using System;
    using System.Collections.Generic;

    public class ConsoleRenderer
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

                foreach (var record in records)
                {
                    int position = 1;
                    Console.WriteLine(Constants.ResultsInformationMessage, position, record.Name, record.Score);
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

        public string GetPlayerName()
        {
            Console.Write(Constants.EnterNameMessage);
            string name = Console.ReadLine();

            return name;
        }

        public string ReadCommand()
        {
            Console.Write(Constants.EnterGuessMessage);
            string command = Console.ReadLine();
            string lowerCaseCommand = command.ToLower();

            return lowerCaseCommand;
        }
    }
}