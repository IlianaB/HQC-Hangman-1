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
                this.renderer.PrintCurrentProgress(this.gameStrategy.GuessedLetters);
                if (this.gameStrategy.isOver())
                {
                    if (this.gameStrategy.HelpUsed)
                    {
                        this.renderer.PrintHelpInformation(this.player.Mistakes);
                    }
                    else
                    {
                        if (scoreBoard.GetWorstTopScore() <= this.player.Mistakes)
                        {
                            this.renderer.PrintScoreInformation(this.player.Mistakes);
                        }
                        else
                        {
                            string name = this.renderer.AskPlayerForName();
                            this.scoreBoard.AddNewScore(name, this.player.Mistakes);
                            this.renderer.PrintScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                        }
                    }
                    this.gameStrategy.ReSet();
                }
                else
                {
                    command = this.renderer.ReadCommand();

                    if (command.Length == 1)
                    {
                        int occuranses = this.gameStrategy.NumberOccuranceOfLetter(command[0]);
                        if (occuranses == 0)
                        {
                            this.player.increaseMistakes();
                            this.renderer.PrintRevealedLetterInformation(command[0]);
                        }
                        else
                        {
                            this.renderer.PrintOccurancesInformation(occuranses);
                        }
                    }
                    else
                    {
                        ExecuteCommand(command);
                    }
                }
            } while (command != "exit");
        }

        private void ExecuteCommand(string command)
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
                        char revealedLetter = this.gameStrategy.RevealALetter();
                        this.renderer.PrintALetterRevealedMessage(revealedLetter);
                    }
                    break;
                case "restart":
                    {
                        scoreBoard.ReSet();
                        this.renderer.PrintWelcomeMessage();
                        this.gameStrategy.ReSet();
                    }
                    break;
                case "exit":
                    {
                        this.renderer.PrintGoodByeMessage();
                        return;
                    } break;
                default:
                    {
                        this.renderer.PrintIncorrectCommandInformation();
                    }
                    break;
            }
        }
    }
}

