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
            Console.WriteLine();

            Console.Write("The secret word is: ");
            for (int i = 0; i < guessedLetters.Length; i++)
            {
                Console.Write("{0} ", guessedLetters[i]);
            }
            Console.WriteLine();
        }

        public void PrintHelpInformation(int mistakes)
        {
            Console.WriteLine("You won with {0} mistake(s) but you have cheated." +
                " You are not allowed to enter into the scoreboard.", mistakes);
        }

        public void PrintScoreInformation(int mistakes)
        {
            Console.WriteLine("You won with {0} mistake(s) but your score did not enter in the scoreboard", mistakes);
        }

        public string AskPlayerForName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();

            return name;
        }

        public string ReadCommand()
        {
            Console.Write("Enter your guess: ");
            string command = Console.ReadLine();
            command.ToLower();

            return command;
        }

        public void PrintRevealedLetterInformation(char letter)
        {
            Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", letter);
        }

        public void PrintOccurancesInformation(int occuranses)
        {
            Console.WriteLine("Good job! You revealed {0} letter(s).", occuranses);
        }

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
        }

        public void PrintGoodByeMessage()
        {
            Console.WriteLine("Good bye!");
        }

        public void PrintIncorrectCommandInformation()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        public void PrintALetterRevealedMessage(char letter)
        {
            Console.WriteLine("OK, I reveal for you the next letter '{0}'.", letter);
        }
    }
}
