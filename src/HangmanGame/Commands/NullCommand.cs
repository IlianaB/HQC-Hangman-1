using HangmanGame.HangmanGame.Commands.Common;

namespace HangmanGame.HangmanGame.Commands
{
    public class NullCommand : Command, ICommand
    {
        public NullCommand(GameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
        }
    }
}
