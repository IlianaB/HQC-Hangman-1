namespace HangmanGame.HangmanGame.Commands.Common
{
    public abstract class Command : ICommand
    {
        protected Command(GameEngine engine)
        {
            this.Engine = engine;
        }

        protected GameEngine Engine { get; set; }

        public abstract void Execute();
    }
}
