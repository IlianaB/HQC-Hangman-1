using System;


namespace HangmanGame
{
    public class ConsoleRenderer
    {
        public ConsoleRenderer()
        {

        }

        public void ShowScoreBoardResults(bool isEmptyScoreBoard, string[] scoreNames, int[] mistakes)
        {
            if (isEmptyScoreBoard)
            {
                Console.WriteLine(Constants.EMPTY_SCOREBOARD_MESSAGE);
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 0;
                while (scoreNames[i] != null)
                {
                    Console.WriteLine(Constants.RESULTS_INFORMATION_MESSAGE, i + 1, scoreNames[i], mistakes[i]);
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

            Console.Write(Constants.ANNOUNCE_SECRET_WORD_MESSAGE);
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

        public string getPlayerName()
        {
            Console.Write(Constants.ENTER_NAME_MESSAGE);
            string name = Console.ReadLine();

            return name;
        }

        public string ReadCommand()
        {
            Console.Write(Constants.ENTER_GUESS_MESSAGE);
            string command = Console.ReadLine();
            command.ToLower();

            return command;
        }
    }
}
