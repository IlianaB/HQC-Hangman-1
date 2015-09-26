using System;
using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Commands
{
    public class ExitCommand : Command, ICommand
    {
        public ExitCommand(GameEngine engine)
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