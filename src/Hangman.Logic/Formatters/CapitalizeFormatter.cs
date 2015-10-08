using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Formatters
{
    public class CapitalizeFormatter : IResultFormatter
    {
        public string Format(IPersonalScore record)
        {
            string playerName = this.CapitalizeFirstLetter(record.Name);
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
