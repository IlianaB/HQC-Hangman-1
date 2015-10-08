using System.Collections.Generic;

namespace Hangman.Logic.ScoreBoardServices.Contracts
{
    public interface IScoreBoard
    {
        IList<IPersonalScore> Records { get; set; }
    }
}
