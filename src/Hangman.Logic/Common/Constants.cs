// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="Constants.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

namespace Hangman.Logic.Common
{
    /// <summary>
    /// Class containing all constants.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Welcome message constant.
        /// </summary>
        public const string WelcomeMessage = "Welcome to Hangman game!";

        /// <summary>
        /// Guess the word message constant.
        /// </summary>
        public const string GuessTheWordMessage = "Please guess my secret word!";

        /// <summary>
        /// Goodbye message constant.
        /// </summary>
        public const string GoodbyeMessage = "Good bye!";

        /// <summary>
        /// Incorrect command message constant.
        /// </summary>
        public const string IncorrectCommandMessage = "Incorrect guess or command!";

        /// <summary>
        /// Revealed letter message constant.
        /// </summary>
        public const string RevealedLettersMessage = "Good job! You revealed {0} letter(s).";

        /// <summary>
        /// No revealed letter message constant.
        /// </summary>
        public const string NoRevealedLettersMessage = "Sorry! There are no unrevealed letters “{0}”.";

        /// <summary>
        /// Used help message constant.
        /// </summary>
        public const string UsedHelpMessage = "OK, I reveal for you the next letter '{0}'.";

        /// <summary>
        /// Win with help message constant.
        /// </summary>
        public const string WinWithHelpMessage = "You won with {0} mistake(s) but you have cheated. You are not allowed to enter into the scoreboard.";

        /// <summary>
        /// Game over message constant.
        /// </summary>
        public const string GameOverMessage = "Game over! Try again!";

        /// <summary>
        /// Low score message constant.
        /// </summary>
        public const string LowScoreMessage = "You won with {0} mistake(s) but your score did not enter in the scoreboard";

        /// <summary>
        /// Occurrences message constant.
        /// </summary>
        public const string OccurencesMessage = "Good job! You revealed {0} letter(s).";

        /// <summary>
        /// No occurrences message constant.
        /// </summary>
        public const string NoOccurencesMessage = "Sorry! There are no unrevealed letters “{0}”";

        /// <summary>
        /// Empty scoreboard message constant.
        /// </summary>
        public const string EmptyScoreboardMessage = "Scoreboard is empty!";

        /// <summary>
        /// Results information constant.
        /// </summary>
        public const string ResultsInformationMessage = "{0}. {1} ---> {2} mistake(s)!";

        /// <summary>
        /// Enter name message constant.
        /// </summary>
        public const string EnterNameMessage = "Please enter your name: ";

        /// <summary>
        /// Enter guess message constant.
        /// </summary>
        public const string EnterGuessMessage = "Enter your guess: ";

        /// <summary>
        /// Announce secret word message constant.
        /// </summary>
        public const string AnnounceSecretWordMessage = "The secret word is: ";

        /// <summary>
        /// Already used letter message constant.
        /// </summary>
        public const string AlreadyUsedLetterMessage = "You have already used the letter {0}!";

        /// <summary>
        /// Path to the database.
        /// </summary>
        public const string DatabaseFile = @"../../../Hangman.Logic/Database/Results.txt";

        /// <summary>
        /// Max number of scores in scoreboard.
        /// </summary>
        public const int NumberOfScoresInScoreBoard = 10;

        /// <summary>
        /// Max number of possible player mistakes before game over.
        /// </summary>
        public const int MaxNumberOfPlayerMistakes = 7;

        /// <summary>
        /// Symbol for the word to be guessed mask.
        /// </summary>
        public const char WordMaskChar = '_';
    }
}