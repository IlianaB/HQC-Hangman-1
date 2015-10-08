using Hangman.Logic.Contracts;

namespace Hangman.Logic.Players
{
    public class Player : IPlayer
    {
        public Player(bool hasUsedHelp)
        {
            this.Name = string.Empty;
            this.Mistakes = 0;
            this.HasUsedHelp = hasUsedHelp;
        }

        public string Name { get; set; }

        public int Mistakes { get; private set; }

        public bool HasUsedHelp { get; set; }

        public void IncreaseMistakes()
        {
            this.Mistakes++;
        }

        public void Reset()
        {
            this.Mistakes = 0;
            this.HasUsedHelp = false;
        }
    }
}
