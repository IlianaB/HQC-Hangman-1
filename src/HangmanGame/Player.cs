using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame
{
    public class Player : IPlayer
    {
        public Player(bool hasUsedHelp)
        {
            this.Mistakes = 0;
            this.HasUsedHelp = hasUsedHelp;
        }

        public int Mistakes { get; private set; }

        public bool HasUsedHelp { get; set; }

        public void IncreaseMistakes()
        {
            this.Mistakes++;
        }

        public void Reset()
        {
            this.Mistakes = 0;
        }
    }
}
