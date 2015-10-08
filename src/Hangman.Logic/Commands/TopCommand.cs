using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    public class TopCommand : Command, ICommand
    {
        public TopCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.ScoreBoardService.SortScoreBoard();
            this.Engine.ScoreBoardService.RemoveLastRecords(Constants.NumberOfScoresInScoreBoard);
            this.Engine.Renderer.ShowScoreBoardResults(this.Engine.ScoreBoardService.IsEmpty(), this.Engine.ScoreBoardService.GetAllRecords());
        }
    }
}
