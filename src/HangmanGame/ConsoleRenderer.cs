namespace HangmanGame.HangmanGame
{
    using System;

    public class ConsoleRenderer
    {
        public void ShowScoreBoardResults(bool isEmptyScoreBoard, string[] scoreNames, int[] mistakes)
        {
            if (isEmptyScoreBoard)
            {
                Console.WriteLine(Constants.EmptyScoreboardMessage);
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 0;
                while (scoreNames[i] != null)
                {
                    Console.WriteLine(Constants.ResultsInformationMessage, i + 1, scoreNames[i], mistakes[i]);
                    i++;
                    if (i >= scoreNames.Length)
                    {
                        break;
                    }
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
            command.ToLower();

            return command;
        }
    }
}