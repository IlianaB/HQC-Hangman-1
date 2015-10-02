using System.Collections.Generic;

namespace HangmanGame.HangmanGame.ScoreBoardServices.Contracts
{
    public interface IScoreBoard
    {
        IList<IPersonalScore> Records { get; set; }
    }
}
