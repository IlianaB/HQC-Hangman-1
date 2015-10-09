using System;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Formatters
{
    public class AllCapsFormatter : IResultFormatter
    {
        public string Format(IPersonalScore record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record", "Incorrect IPersonalScore");
            }

            string playerName = this.CapitalizeAllLetters(record.Name);
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
