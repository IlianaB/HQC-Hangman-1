using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.ScoreBoardServices
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
       
    }
}
