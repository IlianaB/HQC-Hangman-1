using System;
using Hangman.Logic.Commands.Common;
using Hangman.Logic.Common;
using Hangman.Logic.Contracts;

namespace Hangman.Logic.Commands
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