// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="HelpCommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

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
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpCommand"/> class.
        /// </summary>
        /// <param name="engine">
        /// The context of the command.
        /// </param>
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