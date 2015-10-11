using Hangman.Logic.Common;
using Hangman.Logic.Contracts;
using Hangman.Logic.Database;
using Hangman.Logic.Engines;
using Hangman.Logic.Factories;
using Hangman.Logic.Players.Contracts;
using Hangman.Logic.ScoreBoardServices.Contracts;
using Hangman.Logic.Words.Contracts;

namespace Hangman.Console.UI.Engines
{
    public class ConsoleEngine : GameEngine
    {
        public ConsoleEngine(
            IScoreBoardService scoreBoardService, 
            IRenderer renderer, 
            IPlayer player, 
            IWordGenerator wordGenerator, 
            ICommandFactory commandFactory, 
            IInputProvider inputProvider)
            : base(scoreBoardService, renderer, player, wordGenerator, commandFactory)
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

        public override void SaveResult(IPersonalScore newRecord)
        {
            base.SaveResult(newRecord);
            DataFileManager.SingletonInstance.SaveResult(newRecord, Constants.DatabaseFile);
        }

        public override void Play()
        {
            if (this.Player.Name == string.Empty)
            {
                this.SetPlayerName();
            }

            base.Play();
        }
    }
}
