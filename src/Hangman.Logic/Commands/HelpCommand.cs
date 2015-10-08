using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
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