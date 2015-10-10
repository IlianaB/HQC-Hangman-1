using Hangman.Logic.Players.Contracts;

namespace Hangman.Logic.Players
{
    /// <summary>
    /// Responsible for all the information about Players.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Initialize the current player with an empty string name and 0 mistakes as a start value.
        /// </summary>
        public Player()
        {
            this.Name = string.Empty;
            this.Mistakes = 0;
            this.HasUsedHelp = false;
        }

        public string Name { get; set; }

        public int Mistakes { get; private set; }

        public bool HasUsedHelp { get; set; }

        /// <summary>
        /// Increase Player's mistakes with one.
        /// </summary>
        public void IncreaseMistakes()
        {
            this.Mistakes++;
        }

        /// <summary>
        /// Reset Player's mistakes to 0 and sets its property HasUsedHelp to false;
        /// </summary>
        public void Reset()
        {
            this.Mistakes = 0;
            this.HasUsedHelp = false;
        }
    }
}
