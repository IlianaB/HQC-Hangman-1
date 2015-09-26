﻿using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.States.Activation;

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
        public ActivationState ActivationState { get; set; }

        public void Start(ActivationState activationState)
        {
            this.ActivationState = activationState;
            this.Renderer.ShowMessage(Constants.WelcomeMessage);

            do
            {
                this.ActivationState.Play();
            }
            while (true);
        }

        public void ReactToPlayerAction(string command)
        {
            if (command.Length == 1)
            {
                this.ExecuteLetterGuess(command[0]);
            }
            else
            {
                this.ExecuteCommand(command);
            }
        }

        private void ExecuteLetterGuess(char letter)
        {
            string message;
            int occuranses = this.GameStrategy.NumberOccuranceOfLetter(letter);

            if (occuranses == 0)
            {
                this.Player.IncreaseMistakes();
                message = string.Format(Constants.NoOccurencesMessage, letter);
                this.Renderer.ShowMessage(message);
            }
            else
            {
                message = string.Format(Constants.OccurencesMessage, occuranses);
                this.Renderer.ShowMessage(message);
            }
        }

        private void ExecuteCommand(string command)
        {
            Command currentCommand = this.CommandFactory.GetCommand(this, command);
            currentCommand.Execute();
        }

        public void FinishTheGame()
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
    }
}