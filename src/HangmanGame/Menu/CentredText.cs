namespace HangmanGame.HangmanGame.Menu
{
    using System;

    class CentredText
    {
        public static void TextToCenter(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}
