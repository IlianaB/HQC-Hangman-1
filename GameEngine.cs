using System;
using System.Collections;
using System.Collections.Generic;

namespace HangmanGame
{
    public class GameEngine
    {
        private readonly ScoreBoard scoreBoard;
        private readonly GameStrategy gameStrategy;
        private readonly ConsoleRenderer renderer;
        private readonly Player player;
        private IDictionary allMessages;

        public GameEngine(ScoreBoard scoreBoard, GameStrategy gameStrategy, ConsoleRenderer renderer, Player player)
        {
            this.scoreBoard = scoreBoard;
            this.gameStrategy = gameStrategy;
            this.renderer = renderer;
            this.player = player;
            this.allMessages = InitializeAllMessages();
        }

        private IDictionary InitializeAllMessages()
        {
            IDictionary dictionaryWithMessages = new Dictionary<string, string>();
            dictionaryWithMessages.Add("welcome", "Welcome to “Hangman” game. Please try to guess my secret word.");
            dictionaryWithMessages.Add("bye", "Good bye!");
            dictionaryWithMessages.Add("incorrect command", "Incorrect guess or command!");
            dictionaryWithMessages.Add("no letter", "Sorry! There are no unrevealed letters “{0}”.");
            dictionaryWithMessages.Add("revealed letter", "Good job! You revealed {0} letter(s).");
            dictionaryWithMessages.Add("help", "OK, I reveal for you the next letter '{0}'.");
            dictionaryWithMessages.Add("win with help", "You won with {0} mistake(s) but you have cheated." +
                " You are not allowed to enter into the scoreboard.");
            dictionaryWithMessages.Add("low score", "You won with {0} mistake(s) but your score did not enter in the scoreboard");
            dictionaryWithMessages.Add("no occurences", "Sorry! There are no unrevealed letters “{0}”.");
            dictionaryWithMessages.Add("occurences info", "Good job! You revealed {0} letter(s).");
                
            return dictionaryWithMessages;
        }

        public void Start()
        {
            string command = null;
            string message = this.allMessages["welcome"].ToString();
            this.renderer.ShowMessage(message);

            do
            {
                this.renderer.ShowCurrentProgress(this.gameStrategy.GuessedLetters);
                
                if (this.gameStrategy.isOver())
                {
                    FinishTheGame();
                }
                else
                {
                    ReactToPlayerAction();
                }
            } while (command != "exit");
        }

        private void ReactToPlayerAction()
        {
            string command = this.renderer.ReadCommand();
            string message = string.Empty;

            if (command.Length == 1)
            {
                int occuranses = this.gameStrategy.NumberOccuranceOfLetter(command[0]);

                if (occuranses == 0)
                {
                    this.player.increaseMistakes();
                    message = string.Format(this.allMessages["no occurences"].ToString(), command[0]);
                    this.renderer.ShowMessage(message);
                }
                else
                {
                    message = string.Format(this.allMessages["occurences info"].ToString(), occuranses);
                    this.renderer.ShowMessage(message);
                }
            }
            else
            {
                ExecuteCommand(command);
            }
        }

        private void FinishTheGame()
        {
            string message = string.Empty;

            if (this.gameStrategy.HelpUsed)
            {
                message = string.Format(this.allMessages["win with help"].ToString(), this.player.Mistakes);
                this.renderer.ShowMessage(message);
            }
            else
            {
                if (scoreBoard.GetWorstTopScore() <= this.player.Mistakes)
                {
                    message = string.Format(this.allMessages["low score"].ToString(), this.player.Mistakes);
                    this.renderer.ShowMessage(message);
                }
                else
                {
                    string name = this.renderer.getPlayerName();
                    this.scoreBoard.AddNewScore(name, this.player.Mistakes);
                    this.renderer.ShowScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                }
            }

            this.gameStrategy.ReSet();
        }

        private void ExecuteCommand(string command)
        {
            var message = string.Empty;

            switch (command)
            {
                case "top":
                    {
                        this.renderer.ShowScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                        return;
                    }
                case "help":
                    {
                        char revealedLetter = this.gameStrategy.RevealALetter();
                        message = string.Format(this.allMessages["help"].ToString(), revealedLetter);
                    }
                    break;
                case "restart":
                    {
                        this.scoreBoard.ReSet();
                        this.gameStrategy.ReSet();
                        message = this.allMessages["welcome"].ToString();
                    }
                    break;
                case "exit":
                    {
                        message = this.allMessages["bye"].ToString();
                    }
                    break;
                default:
                    {
                        message = this.allMessages["incorrect command"].ToString();
                    }
                    break;
            }

            this.renderer.ShowMessage(message);
        }
    }
}

