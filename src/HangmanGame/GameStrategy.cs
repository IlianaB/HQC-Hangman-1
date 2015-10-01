namespace HangmanGame.HangmanGame
{
    using System;
    using System.Linq;

    public class GameStrategy
    {
        private bool helpUsed;
        
        public GameStrategy()
        {
            this.ReSet();
        }

        public bool HelpUsed
        {
            get
            {
                return this.helpUsed;
            }
        }

        public void ReSet()
        {
            this.helpUsed = false;
        }
    }
}
