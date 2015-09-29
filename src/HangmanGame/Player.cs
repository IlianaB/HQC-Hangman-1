namespace HangmanGame.HangmanGame
{
    public class Player
    {
        public Player()
        {
            this.Mistakes = 0;
        }

        public int Mistakes { get; private set; }

        public void IncreaseMistakes()
        {
            this.Mistakes++;
        }

        public void ReSet()
        {
            this.Mistakes = 0;
        }
    }
}
