using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame.HangmanGame.ScoreBoardServices.Contracts
{
    interface IScoreBoard
    {
        IList<IPersonalScore> Records { get; }

    }
}
