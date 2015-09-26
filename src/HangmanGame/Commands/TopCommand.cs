using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Commands
{
    public class TopCommand : Command, ICommand
    {
        public TopCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Renderer.ShowScoreBoardResults(this.Engine.ScoreBoard.IsEmpty, this.Engine.ScoreBoard.Records);
        }
    }
}
