using System;

namespace HangmanGame
{
    class Start
    {
        static void Main()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            GameStrategy gameStrategy = new GameStrategy();
            ConsoleRenderer renderer = new ConsoleRenderer();
            GameEngine gameEngine = new GameEngine(scoreBoard, gameStrategy, renderer);

            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");

            gameEngine.Start();
        }
    }
}
