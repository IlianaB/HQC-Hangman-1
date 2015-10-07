using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Formatters
{
    public class CapitalizeFormatter : IResultFormatter
    {
        public string Format(IPersonalScore record)
        {
            string playerName = CapitalizeFirstLetter(record.Name);
            string result = string.Format("{0} ---> {1} mistake(s)!", playerName, record.Score);

            return result;
        }

        private string CapitalizeFirstLetter(string word)
        {
            string result = char.ToUpper(word[0]) + word.Substring(1).ToLower();

            return result;
        }

    }
}
