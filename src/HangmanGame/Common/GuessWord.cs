namespace HangmanGame.HangmanGame.Common
{
    public class GuessWord
    {
        public GuessWord(string word)
        {
            this.Content = word;
            this.Mask = GetMask(word);
        }

        public string Content { get; set; }
        public char[] Mask { get; set; }

        private char[] GetMask(string word)
        {
            int wordLength = word.Length;
            char[] letters = new char[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                letters[i] = '_';
            }

            return letters;
        }

        public char RevealLetter()
        {
            char revealedLetter = char.MinValue;

            for (int i = 0; i < this.Mask.Length; i++)
            {
                if (this.Mask[i] != '_')
                {
                    continue;
                }

                this.Mask[i] = this.Content[i];
                revealedLetter = this.Content[i];
                break;
            }

            return revealedLetter;
        }

        public int GetNumberOfOccurences(char letter)
        {
            int count = 0;

            for (int i = 0; i < this.Content.Length; i++)
            {
                if (this.Content[i] != letter)
                {
                    continue;
                }

                this.Mask[i] = letter;
                count++;
            }

            return count;
        }
    }
}
