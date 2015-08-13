using System;

namespace HangmanGame
{
    public class GameEngine
    {
        private readonly ScoreBoard scoreBoard;
        private readonly GameStrategy gameStrategy;
        private readonly ConsoleRenderer renderer;
        private readonly Player player;

        public GameEngine(ScoreBoard scoreBoard, GameStrategy gameStrategy, ConsoleRenderer renderer, Player player)
        {
            this.scoreBoard = scoreBoard;
            this.gameStrategy = gameStrategy;
            this.renderer = renderer;
            this.player = player;
        }

        public void Start()
        {
            string command = null;
            do
            {
                Console.WriteLine();
                this.renderer.PrintCurrentProgress(this.gameStrategy.GuessedLetters);
                if (this.gameStrategy.isOver())
                {
                    if (this.gameStrategy.HelpUsed)
                    {
                        Console.WriteLine("You won with {0} mistake(s) but you have cheated." +
                            " You are not allowed to enter into the scoreboard.", this.player.Mistakes);
                    }
                    else
                    {
                        if (scoreBoard.GetWorstTopScore() <= this.player.Mistakes)
                        {
                            Console.WriteLine("You won with {0} mistake(s) but you score did not enter in the scoreboard",
                                this.player.Mistakes);
                        }
                        else
                        {
                            Console.Write("Please enter your name for the top scoreboard: ");
                            string name = Console.ReadLine();
                            scoreBoard.AddNewScore(name, this.player.Mistakes);
                            this.renderer.PrintScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                        }
                    }
                    this.gameStrategy.ReSet();
                }
                else
                {
                    Console.Write("Enter your guess: ");
                    command = Console.ReadLine();
                    command.ToLower();
                    if (command.Length == 1)
                    {
                        int occuranses = this.gameStrategy.NumberOccuranceOfLetter(command[0]);
                        if (occuranses == 0)
                        {
                            this.player.increaseMistakes();
                            Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", command[0]);
                        }
                        else
                        {
                            Console.WriteLine("Good job! You revealed {0} letter(s).", occuranses);
                        }
                    }
                    else
                    {
                        ExecuteCommand(command, scoreBoard, this.gameStrategy);
                    }
                }
            } while (command != "exit");
        }

        private void ExecuteCommand(string command, ScoreBoard scoreBoard, GameStrategy game)
        {
            switch (command)
            {
                case "top":
                    {
                        this.renderer.PrintScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                    }
                    break;
                case "help":
                    {
                        char revealedLetter = game.RevealALetter();
                        Console.WriteLine("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                    }
                    break;
                case "restart":
                    {
                        scoreBoard.ReSet();
                        Console.WriteLine("\nWelcome to “Hangman” game. Please try to guess my secret word.");
                        game.ReSet();
                    }
                    break;
                case "exit":
                    {
                        Console.WriteLine("Good bye!");
                        return;
                    } break;
                default:
                    {
                        Console.WriteLine("Incorrect guess or command!");
                    }
                    break;
            }
        }
    }
}

