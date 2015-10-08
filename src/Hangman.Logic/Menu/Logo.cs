namespace Hangman.Logic.Menu
{
    using System;

    public class Logo
    {
        public static void LogoDraw()
        {
            var arr = new[]
            {
@" _    _                                            _____                       ",
@"| |  | |                                          / ____|                      ",
@"| |__| | __ _ _ __   __ _ _ __ ___   __ _ _ __   | |  __  __ _ _ __ ___   ___  ",
@"|  __  |/ _` | '_ \ / _` | '_ ` _ \ / _` | '_ \  | | |_ |/ _` | '_ ` _ \ / _ \ ",
@"| |  | | (_| | | | | (_| | | | | | | (_| | | | | | |__| | (_| | | | | | |  __/ ",
@"|_|  |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|  \_____|\__,_|_| |_| |_|\___| ",
@"                     __/ |                                                     ",
@"                    |___/                                                      ",
@"                                                                               ",
@"                           +-+-+-+-+ +-+-+-+-+-+-+-+-+                         ",
@"                           |T|e|a|m| |H|a|n|g|m|a|n|1|                         ",
@"                           +-+-+-+-+ +-+-+-+-+-+-+-+-+                         ",
@"                                                                               ",
@"                                                                               ",
@"                                                                               ",
           };

            Console.WindowWidth = 80;
            Console.WriteLine("\n\n");

            foreach (string line in arr)
            {
                Console.WriteLine(line);
            }
        }
    }
}
