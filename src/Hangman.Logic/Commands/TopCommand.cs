// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="TopCommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

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
        /// <summary>
        /// Initializes a new instance of the <see cref="TopCommand"/> class.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
        public TopCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Gets the top scores in the ScoreBoard and ask the Renderer to print them.
        /// </summary>
        public override void Execute()
        {
            ICollection<IPersonalScore> topScores = this.Engine.ScoreBoardService.GetTopScores(Constants.NumberOfScoresInScoreBoard);
            bool isEmptyScoreBoard = this.Engine.ScoreBoardService.IsEmpty();

            this.Engine.Renderer.ShowScoreBoardResults(isEmptyScoreBoard, topScores);
        }
    }
}
