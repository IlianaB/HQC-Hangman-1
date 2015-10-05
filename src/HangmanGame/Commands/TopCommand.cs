using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;

namespace HangmanGame.HangmanGame.Commands
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
            this.Engine.Renderer.ShowScoreBoardResults(this.Engine.ScoreBoardService.IsEmpty(), this.Engine.ScoreBoard.Records);
        }
    }
}
