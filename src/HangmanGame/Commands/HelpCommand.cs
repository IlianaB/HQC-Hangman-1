using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Commands
{
    public class HelpCommand : Command, ICommand
    {
        public HelpCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            char revealedLetter = this.Engine.GameStrategy.RevealALetter();
            string message = string.Format(Constants.UsedHelpMessage, revealedLetter);
            this.Engine.Renderer.ShowMessage(message);
        }
    }
}