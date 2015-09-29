using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Commands
{
    public class RestartCommand : Command, ICommand
    {
        public RestartCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.ScoreBoardService.ReSet();
            this.Engine.GameStrategy.ReSet();
            this.Engine.Renderer.ShowMessage(Constants.WelcomeMessage);
        }
    }
}