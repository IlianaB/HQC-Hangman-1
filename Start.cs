using System;

namespace HangmanGame
{
    class Start
    {
        static void Main()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            GameStrategy game = new GameStrategy();
            GameEngine gameEngine = new GameEngine(scoreBoard, game);

            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");

            gameEngine.Start();
        }
    }
}
