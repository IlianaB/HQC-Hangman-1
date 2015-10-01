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
    public class GameEngine : ICommandExecutable
    {
        public GameEngine(IScoreBoard scoreBoard, ScoreBoardService scoreBoardService, IRenderer renderer, IInputProvider inputProvider,
            Player player, WordGenerator wordGenerator, CommandFactory commandFactory, DataManager dataManager)
        {
            this.ScoreBoard = scoreBoard;
            this.ScoreBoardService = scoreBoardService;
            this.Renderer = renderer;
            this.InputProvider = inputProvider;
            this.Player = player;
            this.WordGenerator = wordGenerator;
            this.CommandFactory = commandFactory;
            this.DataManager = dataManager;
        }

        public IScoreBoard ScoreBoard { get; private set; }
        public ScoreBoardService ScoreBoardService { get; private set; }
        public IRenderer Renderer { get; private set; }
        public IInputProvider InputProvider { get; private set; }
        public Player Player { get; private set; }
        public WordGenerator WordGenerator { get; private set; }
        public CommandFactory CommandFactory { get; private set; }
        public ActivationState ActivationState { get; set; }
        public GuessWord WordToGuess { get; private set; }
        public DataManager DataManager { get; private set; }
        public bool IsHelpUsed { get; set; }

        public void StartGame(ActivationState activationState)
        {
            string word = this.WordGenerator.GetRandomWord();
            this.WordToGuess = new GuessWord(word);
            this.IsHelpUsed = false;

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

        private void ExecuteCommand(string command)
        {
            Command currentCommand = this.CommandFactory.GetCommand(this, command);
            currentCommand.Execute();
        }

        public bool CheckWinningCondition()
        {
            bool isGameOver = this.WordToGuess.Mask.All(t => t != '_');
            
            return isGameOver;
        }

        public void FinishGame()
        {
            string message;

            if (this.IsHelpUsed)
            {
                message = string.Format(Constants.WinWithHelpMessage, this.Player.Mistakes);
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

                if (playerCanEnterHighScores)
                {
                    string name = this.InputProvider.GetPlayerName();
                    int mistakes = this.Player.Mistakes;
                    IPersonalScore newRecord = new PersonalScore(name, mistakes);
                    this.DataManager.SaveResult(newRecord);
                    this.ScoreBoardService.AddNewScore(newRecord);
                    this.ScoreBoardService.SortScoreBoard();
                    this.Renderer.ShowScoreBoardResults(this.ScoreBoardService.IsEmpty(), this.ScoreBoard.Records);
                }
                else
                {
                    message = string.Format(Constants.LowScoreMessage, this.Player.Mistakes);
                    this.Renderer.ShowMessage(message);
                }
            }

            this.ResetGame();
        }

        public void ResetGame()
        {
            this.Player.ReSet();
            ActivationState activationState = new ActiveState(this);
            StartGame(activationState);
        }
    }
}