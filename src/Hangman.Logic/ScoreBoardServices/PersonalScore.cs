using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.ScoreBoardServices
{
    public class PersonalScore : IPersonalScore
    {
      public PersonalScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name { get; private set; }

        public int Score { get; private set; }

        public override string ToString()
        {
            return this.Name + " - " + this.Score;
        }
    }
}