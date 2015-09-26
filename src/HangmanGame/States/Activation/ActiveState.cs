namespace HangmanGame.HangmanGame.States.Activation
{
    public class ActiveState : ActivationState
    {
        public ActiveState(GameEngine engine)
            : base(engine)
        {
        }

        public override void Play()
        {
            if (this.Engine.GameStrategy.IsOver())
            {
                this.Engine.ActivationState = new InactiveState(this.Engine);
                return;
            }

            string command = this.Engine.Renderer.ReadCommand();
            this.Engine.ReactToPlayerAction(command);
        }
    }
}
