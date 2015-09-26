using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Commands
{
    public class WrongCommand : Command, ICommand
    {
        public WrongCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Renderer.ShowMessage(Constants.IncorrectCommandMessage);
        }
    }
}
