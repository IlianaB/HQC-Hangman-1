using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Formatters
{
    public interface IResultFormatter
    {
        string Format(IPersonalScore record);
    }
}
