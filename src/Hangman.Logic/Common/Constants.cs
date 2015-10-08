﻿namespace Hangman.Logic.Common
{
    public class Constants
    {
        public const string WelcomeMessage = "Welcome to Hangman game!";
        public const string GoodbyeMessage = "Good bye!";
        public const string IncorrectCommandMessage = "Incorrect guess or command!";
        public const string RevealedLettersMessage = "Good job! You revealed {0} letter(s).";
        public const string NoRevealedLettersMessage = "Sorry! There are no unrevealed letters “{0}”.";
        public const string UsedHelpMessage = "OK, I reveal for you the next letter '{0}'.";
        public const string WinWithHelpMessage = "You won with {0} mistake(s) but you have cheated. You are not allowed to enter into the scoreboard.";
        public const string GameOverMessage = "Game over! Try again!";
        public const string LowScoreMessage = "You won with {0} mistake(s) but your score did not enter in the scoreboard";
        public const string OccurencesMessage = "Good job! You revealed {0} letter(s).";
        public const string NoOccurencesMessage = "Sorry! There are no unrevealed letters “{0}”";
        public const string EmptyScoreboardMessage = "Scoreboard is empty!";
        public const string ResultsInformationMessage = "{0}. {1} ---> {2} mistake(s)!";
        public const string EnterNameMessage = "Please enter your name: ";
        public const string EnterGuessMessage = "Enter your guess: ";
        public const string AnnounceSecretWordMessage = "The secret word is: ";
        public const string FilePathConsoleGame = @"../../../Hangman.Logic/Database/Results.txt";
        public const string FilePathWPFGame = @"../../../Hangman.Logic/Database/Results.txt";
        public const int NumberOfScoresInScoreBoard = 10;
        public const int MaxNumberOfPlayerMistakes = 7;
        public const char WordMaskChar = '_';
    }
}