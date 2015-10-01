namespace HangmanGame.HangmanGame.States.Activation
{
    public class InactiveState : ActivationState
    {
        public InactiveState(GameEngine engine)
            : base(engine)
        {
        }

        public override void Play()
        {
            this.Engine.ActivationState = new ActiveState(this.Engine);
            this.Engine.FinishGame();
        }
    }
}
