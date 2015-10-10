using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Help command.
    /// </summary>
    public class HelpCommand : Command, ICommand
    {
        public HelpCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Ask for a letter of the WordToGuess to be revealed, informs the Player with a message and sets Player's property UsedHelp to true.
        /// </summary>
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