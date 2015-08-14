using System;

namespace HangmanGame
{
    public class Constants
    {
        public const string WELCOME_MESSAGE = "Welcome to “Hangman” game. Please try to guess my secret word.";
        public const string GOODBYE_MESSAGE = "Good bye!";
        public const string INCORRECT_COMMAND_MESSAGE = "Incorrect guess or command!";
        public const string REVEALED_LETTERS_MESSAGE = "Good job! You revealed {0} letter(s).";
        public const string NO_REVEALED_LETTERS_MESSAGE = "Sorry! There are no unrevealed letters “{0}”.";
        public const string USED_HELP_MESSAGE = "OK, I reveal for you the next letter '{0}'.";
        public const string WIN_WITH_HELP_MESSAGE = "You won with {0} mistake(s) but you have cheated. You are not allowed to enter into the scoreboard.";
        public const string LOW_SCORE_MESSAGE = "You won with {0} mistake(s) but your score did not enter in the scoreboard";
        public const string OCCURENCES_MESSAGE = "Good job! You revealed {0} letter(s).";
        public const string NO_OCCURENCES_MESSAGE = "Sorry! There are no unrevealed letters “{0}”";
        public const string EMPTY_SCOREBOARD_MESSAGE = "Scoreboard is empty!";
        public const string RESULTS_INFORMATION_MESSAGE = "{0}. {1} ---> {2} mistacke(s)!";
        public const string ENTER_NAME_MESSAGE = "Please enter your name for the top scoreboard: ";
        public const string ENTER_GUESS_MESSAGE = "Enter your guess: ";
        public const string ANNOUNCE_SECRET_WORD_MESSAGE = "The secret word is: ";
    }
}
