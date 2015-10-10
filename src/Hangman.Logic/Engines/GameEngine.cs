// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="GameEngine.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

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
    /// It is also responsible for checking the winning and loosing conditions of the game.
    /// The class is abstract. It implements two interfaces - IEngine and ICommandExecutable (letting the Engine acts like something on which we can perform a command).
    /// </summary>
    public abstract class GameEngine : IEngine, ICommandExecutable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        /// <param name="scoreBoardService">Instance of IScoreBoardService</param>
        /// <param name="renderer">Instance of IRenderer</param>
        /// <param name="player">Instance of IPlayer</param>
        /// <param name="wordGenerator">Instance of IWordGenerator</param>
        /// <param name="commandFactory">Instance of ICommandFactory</param>
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

        /// <summary>
        /// Gets an implementation of IScoreBoardService
        /// </summary>
        public IScoreBoardService ScoreBoardService { get; private set; }

        /// <summary>
        /// Gets an implementation of IRenderer
        /// </summary>
        public IRenderer Renderer { get; private set; }

        /// <summary>
        /// Gets an implementation of IPlayer
        /// </summary>
        public IPlayer Player { get; private set; }

        /// <summary>
        /// Gets an implementation of IWordGenerator
        /// </summary>
        public IWordGenerator WordGenerator { get; private set; }

        /// <summary>
        /// Gets an implementation of ICommandFactory
        /// </summary>
        public ICommandFactory CommandFactory { get; private set; }

        /// <summary>
        /// Gets or sets an implementation of IGuessWord
        /// </summary>
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
        /// The method checks if the Player has used help and if he does not - it checks if the Player can enter High Scores and processes his score.
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
        /// Boolean variable saying if the game is over or not. 
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
        /// If the command has length = 1, the method invokes ExecuteLetterGuess method.
        /// If the command length is > 1, the method gets a command from the Command Factory (using the input parameters) and invokes ExecuteCommand method.
        /// </summary>
        /// <param name="command">Command as a string, read by the Input provider.</param>
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

        /// <summary>
        /// Sets the player's name. Can be overridden by inheritors.
        /// </summary>
        protected virtual void SetPlayerName()
        {
        }

        /// <summary>
        /// Waits for player action. Can be overridden by inheritors. 
        /// </summary>
        protected virtual void WaitForPlayerAction()
        {
        }

        /// <summary>
        /// Saves results. Can be overridden by inheritors.
        /// </summary>
        /// <param name="newRecord">
        /// Player's personal score.
        /// </param>
        protected virtual void SaveResult(IPersonalScore newRecord)
        {
            this.ScoreBoardService.AddNewScore(newRecord);
        }

        /// <summary>
        /// Shows the current progress of the guessed word, invokes the method, waiting for a player's action.
        /// </summary>
        protected virtual void Play()
        {
            this.Renderer.ShowMessage(Constants.GuessTheWordMessage);
            this.Renderer.ShowCurrentProgress(this.WordToGuess.Mask);

            this.WaitForPlayerAction();
        }

        /// <summary>
        /// Process the letter guess of the Player. Checks if he has already used the currently guessed letter or not.
        /// If he used the letter, the method invokes the ProcessGuessedLetter method.
        /// </summary>
        /// <param name="letter">
        /// A letter, write by the Player.
        /// </param>
        private void ExecuteLetterGuess(char letter)
        {
            bool isLetterUsed = this.Player.CheckIfLetterIsUsed(letter);

            if (isLetterUsed)
            {
                this.Renderer.ShowMessage(string.Format(Constants.AlreadyUsedLetterMessage, letter));
            }
            else
            {
                this.ProcessGuessedLetter(letter);
            }

            this.Renderer.ShowCurrentProgress(this.WordToGuess.Mask);
        }

        /// <summary>
        /// Checks how many occurrences of the word are there in the word to be guessed.
        /// If there is not any - increases the Player's mistakes and ask the Renderer to draw the Hangman.
        /// </summary>
        /// <param name="letter">
        /// The guessed letter of the player.
        /// </param>
        private void ProcessGuessedLetter(char letter)
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

            this.Player.AddNewUsedLetter(letter);
            this.Renderer.ShowMessage(message);
        }

        /// <summary>
        /// Executes a command, invoking the method Execute of the received command.
        /// </summary>
        /// <param name="command">
        /// Concrete implementation of ICommand interface.
        /// </param>
        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }

        /// <summary>
        /// Processes the result of the player.
        /// If player can enter high scores - saves the Player's result.
        /// </summary>
        /// <param name="playerCanEnterHighScores">
        /// Boolean variable indicating if the player can enter high scores.
        /// </param>
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