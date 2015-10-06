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
            this.Engine.Renderer.ShowCurrentProgress(this.Engine.WordToGuess.Mask);

            bool isGameOver = this.Engine.CheckGameOverCondition();
            bool isWordGuessed = this.Engine.CheckWinningCondition();

            if (isGameOver)
            {
                this.Engine.ActivationState = new InactiveState(this.Engine);
                this.Engine.Renderer.ShowMessage(Constants.GameOverMessage);
                return;
            }

            if (isWordGuessed)
            {
                this.Engine.ActivationState = new InactiveState(this.Engine);
                return;
            }

            string command = this.Engine.InputProvider.ReadCommand();
            this.Engine.ReactToPlayerAction(command);
        }
    }
}
