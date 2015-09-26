﻿using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Factories;

namespace HangmanGame.HangmanGame
{
    public class GameEngine
    {
        public GameEngine(ScoreBoard scoreBoard, GameStrategy gameStrategy, ConsoleRenderer renderer, Player player, CommandFactory commandFactory)
        {
            this.ScoreBoard = scoreBoard;
            this.GameStrategy = gameStrategy;
            this.Renderer = renderer;
            this.Player = player;
            this.CommandFactory = commandFactory;
        }

        public ScoreBoard ScoreBoard { get; set; }
        public GameStrategy GameStrategy { get; set; }
        public ConsoleRenderer Renderer { get; set; }
        public Player Player { get; set; }
        public CommandFactory CommandFactory { get; set; }

        public void Start()
        {
            string command = null;
            string message = Constants.WelcomeMessage;
            this.Renderer.ShowMessage(message);

            do
            {
                this.Renderer.ShowCurrentProgress(this.GameStrategy.GuessedLetters);

                if (this.GameStrategy.IsOver())
                {
                    this.FinishTheGame();
                }
                else
                {
                    command = this.Renderer.ReadCommand();
                    this.ReactToPlayerAction(command);
                }
            }
            while (command != "exit");
        }

        private void ReactToPlayerAction(string command)
        {
            if (command.Length == 1)
            {
                string message;
                int occuranses = this.GameStrategy.NumberOccuranceOfLetter(command[0]);

                if (occuranses == 0)
                {
                    this.Player.IncreaseMistakes();
                    message = string.Format(Constants.NoOccurencesMessage, command[0]);
                    this.Renderer.ShowMessage(message);
                }
                else
                {
                    message = string.Format(Constants.OccurencesMessage, occuranses);
                    this.Renderer.ShowMessage(message);
                }
            }
            else
            {
                this.ExecuteCommand(command);
            }
        }

        private void FinishTheGame()
        {
            string message;

            if (this.GameStrategy.HelpUsed)
            {
                message = string.Format(Constants.WinWithHelpMessage, this.Player.Mistakes);
                this.Renderer.ShowMessage(message);
            }
            else
            {
                bool playerCanEnterHighScores = true;

                if (!this.ScoreBoard.IsEmpty)
                {
                    playerCanEnterHighScores = this.ScoreBoard.GetWorstTopScore(Constants.TopScores) >=
                                                 this.Player.Mistakes;
                }

                if (playerCanEnterHighScores)
                {
                    string name = this.Renderer.GetPlayerName();
                    int mistakes = this.Player.Mistakes;
                    Record newRecord = new Record(name, mistakes);
                    this.ScoreBoard.AddNewScore(newRecord);
                    this.Renderer.ShowScoreBoardResults(this.ScoreBoard.IsEmpty, this.ScoreBoard.Records);
                }
                else
                {
                    message = string.Format(Constants.LowScoreMessage, this.Player.Mistakes);
                    this.Renderer.ShowMessage(message);
                }
            }

            this.GameStrategy.ReSet();
        }

        private void ExecuteCommand(string command)
        {
            Command currentCommand = this.CommandFactory.GetCommand(this, command);
            currentCommand.Execute();
        }
    }
}