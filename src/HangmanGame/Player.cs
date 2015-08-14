using System;

namespace HangmanGame
{
    public class Player
    {
        public Player()
        {
            this.Mistakes = 0;
        }

        public int Mistakes { get; private set; }

        public void increaseMistakes()
        {
            this.Mistakes++;
        }
    }
}
