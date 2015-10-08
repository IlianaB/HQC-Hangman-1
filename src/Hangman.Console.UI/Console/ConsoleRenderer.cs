﻿using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Formatters;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.UIInteractors;

namespace Hangman.Console.UI.Console
{
    using System;
    using System.Collections.Generic;

    public class ConsoleRenderer : Renderer, IRenderer
    {
        public ConsoleRenderer()
            : this(new CapitalizeFormatter())
        {
        }

        public ConsoleRenderer(IResultFormatter formatter)
            : base(formatter)
        {
        }

        public override void ShowScoreBoardResults(bool isEmptyScoreBoard, ICollection<IPersonalScore> records)
        {
            if (isEmptyScoreBoard)
            {
                Console.WriteLine(Constants.EmptyScoreboardMessage);
            }
            else
            {
                Console.WriteLine("Scoreboard:");

                int position = 1;
                foreach (var record in records)
                {
                    Console.WriteLine(position + ". " + this.Formatter.Format(record));
                    position++;
                }
            }
        }

        public override void ShowCurrentProgress(char[] guessedLetters)
        {
            Console.WriteLine();

            Console.Write(Constants.AnnounceSecretWordMessage);

            for (int i = 0; i < guessedLetters.Length; i++)
            {
                Console.Write("{0} ", guessedLetters[i]);
            }

            Console.WriteLine();
        }

        public override void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public override void DrawHangman(int mistakes)
        {
            switch (mistakes)
            {
                case 1:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;

                case 2:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 3:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 4:

                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 5:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 6:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |    /");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 7:
                    Console.WriteLine("   _____");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |     O");
                    Console.WriteLine("  |    \\|/");
                    Console.WriteLine("  |     |");
                    Console.WriteLine("  |    / \\");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
            }
        }
    }
}