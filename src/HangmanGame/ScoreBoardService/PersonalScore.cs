using HangmanGame.HangmanGame.ScoreBoardService.Contracts;

namespace HangmanGame.HangmanGame.ScoreBoardService
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
