using System.Linq;

using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Factories;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Logic.Engines
{
    /// <summary>
    /// GameEngine class controls the main game flow. It has methods for starting, resetting, and ending a game. 
    /// It is also responsible for checking the winning and looosing conditions of the game.
    /// The class is abstract. It implements two interfaces - IEngine and ICommandExecutable (letting the Engine acts like something on which we can perform a command).
    /// </summary>
    public abstract class GameEngine : IEngine, ICommandExecutable
    {
        protected GameEngine(
            IScoreBoardService scoreBoardService, 
            IRenderer renderer,
            IPlayer player, 
            IWordGenerator wordGenerator, 
            ICommandFactory commandFactory)
        {
            this.ScoreBoardService = scoreBoardService;
            this.Renderer = renderer;
            this.Player = player;
            this.WordGenerator = wordGenerator;
            this.CommandFactory = commandFactory;
        }

        public IScoreBoardService ScoreBoardService { get; private set; }

        public IRenderer Renderer { get; private set; }

        public IPlayer Player { get; private set; }

        public IWordGenerator WordGenerator { get; private set; }

        public ICommandFactory CommandFactory { get; private set; }

        public IGuessWord WordToGuess { get; set; }

        /// <summary>
        /// Creates a setup for the current game:
        /// Initializes a new WordToGuess, prints welcome message and invokes the Play method.
        /// </summary>
        public void StartGame()
        {
            string word = this.WordGenerator.GetRandomWord();
            this.WordToGuess = new GuessWord(word);
            this.Renderer.ShowMessage(Constants.WelcomeMessage);
            this.Play();
        }


        /// <summary>
        /// Ends a won game. 
        /// The method checks if the Player has used help and if he does not - it checks if the Player can enter Hihg Scores and processes his score.
        /// </summary>
        public void EndWonGame()
        {
            if (this.Player.HasUsedHelp)
            {
                string message = string.Format(Constants.WinWithHelpMessage, this.Player.Mistakes);
                this.Renderer.ShowMessage(message);
            }
            else
            {
                bool playerCanEnterHighScores = this.ScoreBoardService.CheckIfPlayerCanEnterHighScores(this.Player);

                this.ProcessCurrentPlayerResult(playerCanEnterHighScores);
            }

            this.ResetGame();
        }

        /// <summary>
        /// Shows Game Over message and invokes RestartGame method.
        /// </summary>
        public void EndLostGame()
        {
            this.Renderer.ShowMessage(Constants.GameOverMessage);
            this.ResetGame();
        }

        /// <summary>
        /// Invokes the Player's Reset method to ensure he starts the new game with 0 mistakes and invokes StartGame method.
        /// </summary>
        public void ResetGame()
        {
            this.Player.Reset();
            this.StartGame();
        }

        /// <summary>
        /// Checks if the Player has made more mistakes than the maximum possible mistakes.
        /// </summary>
        /// <returns>
        /// Boolean variable saying if the game is over or not 
        /// </returns>
        public bool CheckGameOverCondition()
        {
            if (this.Player.Mistakes >= Constants.MaxNumberOfPlayerMistakes)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the Player has guessed the secret word.
        /// </summary>
        /// <returns>
        /// Boolean variable saying if the Player has guessed the secret word or not.
        /// </returns>
        public bool CheckWinningCondition()
        {
            bool isGameOver = this.WordToGuess.Mask.All(t => t != Constants.WordMaskChar);

            return isGameOver;
        }

        /// <summary>
        /// Reacts to player action, received as a string command.
        /// If the command has lenght = 1, the method invokes ExecuteLetterGuess method.
        /// If the command lenght is > 1, the method gets a command from the Command Factory (using the input param) and incokes ExecuteCommand method.
        /// </summary>
        /// <param name="command">Command as a string, read by the Input provider</param>
        public void ReactToPlayerAction(string command)
        {
            if (command.Length == 1)
            {
                this.ExecuteLetterGuess(command[0]);
            }
            else
            {
                ICommand currentCommand = this.CommandFactory.GetGommand(this, command);
                this.ExecuteCommand(currentCommand);
            }
        }

        protected virtual void SetPlayerName()
        {
        }

        protected virtual void WaitForPlayerAction()
        {
        }

        protected virtual void SaveResult(IPersonalScore newRecord)
        {
            this.ScoreBoardService.AddNewScore(newRecord);
        }

        protected virtual void Play()
        {
            this.Renderer.ShowMessage(Constants.GuessTheWordMessage);
            this.Renderer.ShowCurrentProgress(this.WordToGuess.Mask);

            this.WaitForPlayerAction();
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

                this.Renderer.ShowScoreBoardResults(this.ScoreBoardService.IsEmpty(), this.ScoreBoardService.GetTopScores(Constants.NumberOfScoresInScoreBoard));
            }
            else
            {
                string message = string.Format(Constants.LowScoreMessage, this.Player.Mistakes);
                this.Renderer.ShowMessage(message);
            }
        }
    }
}