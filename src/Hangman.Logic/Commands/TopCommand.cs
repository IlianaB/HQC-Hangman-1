using System.Collections.Generic;
using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Top command.
    /// </summary>
    public class TopCommand : Command, ICommand
    {
        public TopCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Gets the top scores in the ScoreaBoard and ask the Renderer to print them.
        /// </summary>
        public override void Execute()
        {
            ICollection<IPersonalScore> topScores = this.Engine.ScoreBoardService.GetTopScores(Constants.NumberOfScoresInScoreBoard);
            bool isEmptyScoreBoard = this.Engine.ScoreBoardService.IsEmpty();

            this.Engine.Renderer.ShowScoreBoardResults(isEmptyScoreBoard, topScores);
        }
    }
}
