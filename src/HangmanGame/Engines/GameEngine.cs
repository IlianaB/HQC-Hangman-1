﻿using System.Linq;

using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame
{
    public abstract class GameEngine : ICommandExecutable, IEngine
    {
        public GameEngine(IScoreBoard scoreBoard, ScoreBoardService scoreBoardService, IRenderer renderer,
                        IPlayer player, WordGenerator wordGenerator, CommandFactory commandFactory)
        {
            this.ScoreBoard = scoreBoard;
            this.ScoreBoardService = scoreBoardService;
            this.Renderer = renderer;
            this.Player = player;
            this.WordGenerator = wordGenerator;
            this.CommandFactory = commandFactory;
        }

        public IScoreBoard ScoreBoard { get; private set; }

        public ScoreBoardService ScoreBoardService { get; private set; }

        public IRenderer Renderer { get; private set; }

        public IPlayer Player { get; private set; }

        public WordGenerator WordGenerator { get; private set; }

        public CommandFactory CommandFactory { get; private set; }

        public GuessWord WordToGuess { get; private set; }


        public void StartGame()
        {
            string word = this.WordGenerator.GetRandomWord();
            this.WordToGuess = new GuessWord(word);
            this.Renderer.ShowMessage(Constants.WelcomeMessage);
            this.Play();
        }

        public void FinishGame()
        {
            if (!this.CheckGameOverCondition())
            {
                if (this.Player.HasUsedHelp)
                {
                    string message = string.Format(Constants.WinWithHelpMessage, this.Player.Mistakes);
                    this.Renderer.ShowMessage(message);
                }
                else
                {
                    bool playerCanEnterHighScores = true;

                    if (!this.ScoreBoardService.IsEmpty() && this.ScoreBoardService.IsFull(Constants.NumberOfScoresInScoreBoard))
                    {
                        var worstScore = this.ScoreBoardService.GetWorstScoreEntry(Constants.NumberOfScoresInScoreBoard);
                        playerCanEnterHighScores = worstScore >= this.Player.Mistakes;
                    }

                    this.ProcessCurrentPlayerResult(playerCanEnterHighScores);
                }
            }

            this.ResetGame();
        }

        public void ResetGame()
        {
            this.Player.Reset();
            this.StartGame();
        }

        public bool CheckGameOverCondition()
        {
            if (this.Player.Mistakes >= 7)
            {
                return true;
            }

            return false;
        }

        public bool CheckWinningCondition()
        {
            bool isGameOver = this.WordToGuess.Mask.All(t => t != '_');

            return isGameOver;
        }

        public void ReactToPlayerAction(string command)
        {
            if (command.Length == 1)
            {
                this.ExecuteLetterGuess(command[0]);
            }
            else
            {
                ICommand currentCommand = this.CommandFactory.GetCommand(this, command);
                this.ExecuteCommand(currentCommand);
            }
        }

        private void ExecuteLetterGuess(char letter)
        {
            string message;
            int occuranses = this.WordToGuess.GetNumberOfOccurences(letter);

            if (occuranses == 0)
            {
                this.Player.IncreaseMistakes();
                this.Renderer.DrawHangman(this.Player.Mistakes);
                message = string.Format(Constants.NoOccurencesMessage, letter);
            }
            else
            {
                message = string.Format(Constants.OccurencesMessage, occuranses);
            }

            this.Renderer.ShowMessage(message);
            this.Renderer.ShowCurrentProgress(this.WordToGuess.Mask);
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        private void ProcessCurrentPlayerResult(bool playerCanEnterHighScores)
        {
            if (playerCanEnterHighScores)
            {
                int mistakes = this.Player.Mistakes;
                IPersonalScore newRecord = new PersonalScore(this.Player.Name, mistakes);

                this.SaveResult(newRecord);

                this.ScoreBoardService.AddNewScore(newRecord);
                this.ScoreBoardService.SortScoreBoard();
                this.Renderer.ShowScoreBoardResults(this.ScoreBoardService.IsEmpty(), this.ScoreBoard.Records);
            }
            else
            {
                string message = string.Format(Constants.LowScoreMessage, this.Player.Mistakes);
                this.Renderer.ShowMessage(message);
            }
        }

        private void Play()
        {
            if (this.Player.Name == string.Empty)
            {
                this.SetPlayerName();
            }

            this.Renderer.ShowCurrentProgress(this.WordToGuess.Mask);
            this.WaitForPlayerAction();
        }

        protected virtual void SetPlayerName()
        {
        }

        protected virtual void WaitForPlayerAction()
        {
        }

        protected virtual void SaveResult(IPersonalScore newRecord)
        {
        }
    }
}