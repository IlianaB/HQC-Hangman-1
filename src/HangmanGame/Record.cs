namespace HangmanGame.HangmanGame
{
    public class Record
    {
        private string name;
        private int score;

        public Record(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Score
        {
            get { return this.score; }
            private set { this.score = value; }
        }

    }
}
