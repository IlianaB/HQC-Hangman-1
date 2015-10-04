namespace HangmanGame.HangmanGame.Menu
{
    using System;

    public class CentredText
    {
        public static void TextToCenter(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}
