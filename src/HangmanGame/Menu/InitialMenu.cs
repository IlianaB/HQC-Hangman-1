namespace HangmanGame.HangmanGame.Menu
{
    using System;

    public class InitialMenu
    {
        public static void DisplayInitialMenu()
        {
            var options = new string[]
            {
                " Please select:",
                "---------------",
                "[1] New Game   ",
                "[2] How to play",
                "[3] High Scores",
                "[4] Quit       "
            };

            for (int i = 0; i < options.Length; i++)
            {
                Menu.CentredText.TextToCenter(options[i]);
            }

            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            Console.Clear();
            switch (pressedKey.KeyChar)
            {
                case '1':
                    Game game = new Game();
                    game.Initialize();
                    break;
                case '2':
                    //TODO: Implement how to play
                    Console.WriteLine("TODO: Implement how to play");
                    DisplayInitialMenu();
                    break;
                case '3':
                    //TODO: Implement High Score
                    Console.WriteLine("TODO: Implement High Score");
                    DisplayInitialMenu();
                    break;
                case '4':
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:

                    DisplayInitialMenu();
                    break;
            }
        }
    }
}
