namespace HangmanGame.HangmanGame.States.Activation
{
    public abstract class ActivationState
    {
        protected ActivationState(GameEngine engine)
        {
            this.Engine = engine;
        }

        protected GameEngine Engine { get; set; }

        public abstract void Play();
    }
}
