using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Formatters
{
    public class AllCapsFormatter : IResultFormatter
    {
        public string Format(IPersonalScore record)
        {
            string playerName = CapitalizeAllLetters(record.Name);
            string result = string.Format("{0} ---> {1} MISTAKE(S)!", playerName, record.Score);

            return result;
        }

        private string CapitalizeAllLetters(string word)
        {
            string result = word.ToUpper();

            return result;
        }
    }
}
