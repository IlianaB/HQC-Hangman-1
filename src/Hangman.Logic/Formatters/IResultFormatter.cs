using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Formatters
{
    public interface IResultFormatter
    {
        string Format(IPersonalScore record);
    }
}
