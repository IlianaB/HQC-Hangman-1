using System;
using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGame.HangmanGame.Commands
{
    public class ExitCommand : Command, ICommand
    {
        public ExitCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Renderer.ShowMessage(Constants.GoodbyeMessage);
            Environment.Exit(0);
        }
    }
}