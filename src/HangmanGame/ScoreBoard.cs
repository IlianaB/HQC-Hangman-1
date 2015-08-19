namespace HangmanGame.HangmanGame
{
    public class ScoreBoard
    {
        public const int NumberOfScores = 5;

        public ScoreBoard()
        {
            this.ScoreNames = new string[NumberOfScores];
            this.Mistakes = new int[NumberOfScores];

            for (int i = 0; i < this.ScoreNames.Length; i++)
            {
                this.ScoreNames[i] = null;
                this.Mistakes[i] = int.MaxValue;
            }

            this.IsEmpty = true;
        }

        public bool IsEmpty { get; set; }

        public string[] ScoreNames { get; set; }

        public int[] Mistakes { get; set; }

        public void AddNewScore(string nickname, int mistakes)
        {
            int indexToPutNewScore = this.FindIndexWhereToPutNewScore(mistakes);
            if (indexToPutNewScore == this.ScoreNames.Length)
            {
                return;
            }
            
            this.MoveScoresDownByOnePosition(indexToPutNewScore);
            this.ScoreNames[indexToPutNewScore] = nickname;
            this.Mistakes[indexToPutNewScore] = mistakes;
            this.IsEmpty = false;
        }

        private int FindIndexWhereToPutNewScore(int mistakes)
        {
            for (int i = 0; i < this.Mistakes.Length; i++)
            {
                if (mistakes < this.Mistakes[i])
                {
                    return i;
                }
            }

            return this.ScoreNames.Length;
        }

        private void MoveScoresDownByOnePosition(int startPosition)
        {
            for (int i = this.ScoreNames.Length - 1; i > startPosition; i--)
            {
                this.ScoreNames[i] = this.ScoreNames[i - 1];
                this.Mistakes[i] = this.Mistakes[i - 1];
            }
        }

        public int GetWorstTopScore()
        {
            int worstTopScore = int.MaxValue;
            if (this.ScoreNames[this.ScoreNames.Length - 1] != null) { worstTopScore = this.Mistakes[this.ScoreNames.Length - 1]; }
            return worstTopScore;
        }

        public void ReSet()
        {
            for (int i = 0; i < this.ScoreNames.Length; i++)
            {
                this.ScoreNames[i] = null;
                this.Mistakes[i] = int.MaxValue;
            }

            this.IsEmpty = true;
        }
    }
}