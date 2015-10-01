using HangmanGame.HangmanGame.Commands.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.States.Activation;

namespace HangmanGame.HangmanGame.Commands
{
    public class StartCommand : Command, ICommand
    {
        public StartCommand(ICommandExecutable engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            ActivationState activationState = new ActiveState(this.Engine as GameEngine);
            this.Engine.StartGame(activationState);
        }
    }
}
