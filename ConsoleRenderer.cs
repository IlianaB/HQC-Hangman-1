using System;


namespace HangmanGame
{
    public class ConsoleRenderer
    {
        public ConsoleRenderer()
        {

        }

        public void PrintScoreBoardResults(bool isEmptyScoreBoard, string[] scoreNames, int[] mistakes)
        {
            if (isEmptyScoreBoard)
            {
                Console.WriteLine("Scoreboard is empty!");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 0;
                while (scoreNames[i] != null)
                {
                    Console.WriteLine("{0}. {1} ---> {2} mistacke(s)!", i + 1, scoreNames[i], mistakes[i]);
                    i++;
                    if (i >= scoreNames.Length)
                    {
                        break;
                    }
                }
            }
        }

        public void PrintCurrentProgress(char[] guessedLetters)
        {
            Console.Write("The secret word is: ");
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                Console.Write("{0} ", guessedLetters[i]);
            }
            Console.WriteLine();
        }

    }
}
