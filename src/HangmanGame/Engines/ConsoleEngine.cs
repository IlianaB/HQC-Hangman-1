using HangmanGame.HangmanGame.Common;
using HangmanGame.HangmanGame.Contracts;
using HangmanGame.HangmanGame.Database;
using HangmanGame.HangmanGame.Factories;
using HangmanGame.HangmanGame.ScoreBoardServices;
using HangmanGame.HangmanGame.ScoreBoardServices.Contracts;

namespace HangmanGame.HangmanGame.Engines
{
    public class ConsoleEngine : GameEngine
    {
        public ConsoleEngine(IScoreBoard scoreBoard, ScoreBoardService scoreBoardService, IRenderer renderer,
                            IPlayer player, WordGenerator wordGenerator, ICommandFactory commandFactory, IInputProvider inputProvider)
            : base(scoreBoard, scoreBoardService, renderer, player, wordGenerator, commandFactory)
        {
            this.InputProvider = inputProvider;
        }

        public IInputProvider InputProvider { get; private set; }

        protected override void WaitForPlayerAction()
        {
            do
            {
                bool isGameOver = this.CheckGameOverCondition();
                bool isWordGuessed = this.CheckWinningCondition();

                if (isGameOver)
                {
                    this.EndLostGame();
                }

                if (isWordGuessed)
                {
                    this.EndWonGame();
                }

                this.Renderer.ShowMessage(Constants.EnterGuessMessage);
                string command = this.InputProvider.ReadCommand();
                this.ReactToPlayerAction(command);
            }
            while (true);
        }

        protected override void SetPlayerName()
        {
            this.Renderer.ShowMessage(Constants.EnterNameMessage);
            string name = this.InputProvider.ReadCommand();
            this.Player.Name = name;
        }

        protected override void SaveResult(IPersonalScore newRecord)
        {
            DataFileManager.SingletonInstance.SaveResult(newRecord, Constants.FilePathConsoleGame);
        }
    }
}
