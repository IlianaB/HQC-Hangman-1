using System.Linq;

using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;
using HangmanGame.HangmanGame.States.Activation;

namespace HangmanGame.HangmanGame
{
    public class GameEngine : ICommandExecutable, IEngine
    {
        public GameEngine(IScoreBoard scoreBoard, ScoreBoardService scoreBoardService, IRenderer renderer, IInputProvider inputProvider,
            IPlayer player, WordGenerator wordGenerator, CommandFactory commandFactory)
        {
            this.ScoreBoard = scoreBoard;
            this.ScoreBoardService = scoreBoardService;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
            this.Player = player;
            this.WordGenerator = wordGenerator;
            this.CommandFactory = commandFactory;
        }

        public IScoreBoard ScoreBoard { get; private set; }

        public ScoreBoardService ScoreBoardService { get; private set; }

        public IRenderer Renderer { get; private set; }

        public IInputProvider InputProvider { get; private set; }

        public IPlayer Player { get; private set; }

        public WordGenerator WordGenerator { get; private set; }

        public CommandFactory CommandFactory { get; private set; }

        public ActivationState ActivationState { get; set; }

        public GuessWord WordToGuess { get; private set; }


        public void StartGame(ActivationState activationState)
        {
            string word = this.WordGenerator.GetRandomWord();
            this.WordToGuess = new GuessWord(word);

            this.ActivationState = activationState;
            this.Renderer.ShowMessage(Constants.WelcomeMessage);

            do
            {
                this.ActivationState.Play();
            }
            while (true);
        }

        public void FinishGame()
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

            this.ResetGame();
        }

        public void ResetGame()
        {
            this.Player.Reset();
            this.StartGame(this.ActivationState);
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
                message = string.Format(Constants.NoOccurencesMessage, letter);
            }
            else
            {
                message = string.Format(Constants.OccurencesMessage, occuranses);
            }

            this.Renderer.ShowMessage(message);
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        private void ProcessCurrentPlayerResult(bool playerCanEnterHighScores)
        {
            if (playerCanEnterHighScores)
            {
                string name = this.InputProvider.GetPlayerName();
                int mistakes = this.Player.Mistakes;
                IPersonalScore newRecord = new PersonalScore(name, mistakes);
                DataFileManager.SingletonInstance().SaveResult(newRecord, Constants.FilePath);
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
    }
}