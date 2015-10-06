﻿using HangmanGame.HangmanGame.Commands;
using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Factories;

namespace HangmanGame.HangmanGame.Menu
{
    using System;

    public class InitialMenu
    {
        public static void DisplayInitialMenu(ICommandExecutable engine, CommandFactory commandFactory)
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

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                Command command = null;

                switch (pressedKey.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        command = new StartCommand(engine);
                        break;
                    case '2':
                        // TODO: Implement how to play
                        Console.WriteLine("TODO: Implement how to play");
                        break;
                    case '3':
                        Console.Clear();
                        command = commandFactory.GetCommand(engine, "top");
                        break;
                    case '4':
                        Console.Clear();
                        command = commandFactory.GetCommand(engine, "exit");
                        break;
                    default:
                        command = commandFactory.GetCommand(engine, null);
                        break;
                }

                command.Execute();
            }
        }
    }
}
