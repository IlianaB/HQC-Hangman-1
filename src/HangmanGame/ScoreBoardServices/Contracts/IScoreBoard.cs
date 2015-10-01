using System.Collections.Generic;

namespace HangmanGame.HangmanGame.ScoreBoardServices.Contracts
{
    interface IScoreBoard
    {
        IList<IPersonalScore> Records { get; }

    }
}
