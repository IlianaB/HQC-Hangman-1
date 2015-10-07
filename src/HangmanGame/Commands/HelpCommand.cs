using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Commands
{
    public class HelpCommand : Command, ICommand
    {
        public HelpCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            char revealedLetter = this.Engine.WordToGuess.RevealLetter();
            string message = string.Format(Constants.UsedHelpMessage, revealedLetter);
            this.Engine.Renderer.ShowMessage(message);
            this.Engine.Renderer.ShowCurrentProgress(this.Engine.WordToGuess.Mask);
            this.Engine.Player.HasUsedHelp = true;
        }
    }
}