// <summary>Hangman Game - Teamwork for the course High-quality code at Telerik Academy</summary>
// <copyright file="ExitCommand.cs" company="Hangman-1">
//     Hangman-Team-1@
// </copyright>

using System;
using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
{
    /// <summary>
    /// A "Concrete Command" - implementation of Command Design Pattern. It performs Exit command.
    /// </summary>
    public class ExitCommand : Command, ICommand
    {
        public ExitCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        /// <summary>
        /// Shows GoodBye message and close the game window.
        /// </summary>
        public override void Execute()
        {
            this.Engine.Renderer.ShowMessage(Constants.GoodbyeMessage);
            Environment.Exit(0);
        }
    }
}