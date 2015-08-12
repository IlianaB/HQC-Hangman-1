using System;

namespace HangmanGame
{
    public class ScoreBoard
    {
        public const int NUMBER_OF_SCORES = 5;

        public ScoreBoard()
        {
            this.ScoreNames = new string[NUMBER_OF_SCORES];
            this.Mistakes = new int[NUMBER_OF_SCORES];

            for (int i = 0; i < ScoreNames.Length; i++)
            {
                ScoreNames[i] = null;
                Mistakes[i] = int.MaxValue;
            }
            this.IsEmpty = true;

        }

        public bool IsEmpty { get; set; }
        public string[] ScoreNames { get; set; }
        public int[] Mistakes { get; set; }


        public void AddNewScore(string nickname, int mistakes)
        {
            int indexToPutNewScore = FindIndexWhereToPutNewScore(mistakes);
            if (indexToPutNewScore == ScoreNames.Length)
            {
                return;
            }
            else
            {
                MoveScoresDownByOnePosition(indexToPutNewScore);
                ScoreNames[indexToPutNewScore] = nickname;
                Mistakes[indexToPutNewScore] = mistakes;
                IsEmpty = false;
            }
        }

        private int FindIndexWhereToPutNewScore(int mistakes)
        {
            for (int i = 0; i < Mistakes.Length; i++)
            {
                if (mistakes < Mistakes[i])
                {
                    return i;
                }
            }
            return ScoreNames.Length;
        }

        private void MoveScoresDownByOnePosition(int startPosition)
        {
            for (int i = ScoreNames.Length - 1; i > startPosition; i--)
            {
                ScoreNames[i] = ScoreNames[i - 1];
                Mistakes[i] = Mistakes[i - 1];
            }
        }

        public int GetWorstTopScore()
        {
            int worstTopScore = int.MaxValue;
            if (ScoreNames[ScoreNames.Length - 1] != null) { worstTopScore = Mistakes[ScoreNames.Length - 1]; }
            return worstTopScore;
        }

        public void ReSet()
        {
            for (int i = 0; i < ScoreNames.Length; i++)
            {
                ScoreNames[i] = null;
                Mistakes[i] = 0;
            }
            IsEmpty = true;
        }
    }
}

