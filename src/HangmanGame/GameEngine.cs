namespace HangmanGame.HangmanGame
{
    public class GameEngine
    {
        private readonly ScoreBoard scoreBoard;
        private readonly GameStrategy gameStrategy;
        private readonly ConsoleRenderer renderer;
        private readonly Player player;

        public GameEngine(ScoreBoard scoreBoard, GameStrategy gameStrategy, ConsoleRenderer renderer, Player player)
        {
            this.scoreBoard = scoreBoard;
            this.gameStrategy = gameStrategy;
            this.renderer = renderer;
            this.player = player;
        }

        public void Start()
        {
            string command = null;
            string message = Constants.WelcomeMessage;
            this.renderer.ShowMessage(message);

            do
            {
                this.renderer.ShowCurrentProgress(this.gameStrategy.GuessedLetters);
                
                if (this.gameStrategy.IsOver())
                {
                    this.FinishTheGame();
                }
                else
                {
                    command = this.renderer.ReadCommand();
                    this.ReactToPlayerAction(command);
                }
            } 
            while (command != "exit");
        }

        private void ReactToPlayerAction(string command)
        {
            if (command.Length == 1)
            {
                int occuranses = this.gameStrategy.NumberOccuranceOfLetter(command[0]);

                string message;

                if (occuranses == 0)
                {
                    this.player.IncreaseMistakes();
                    message = string.Format(Constants.NoOccurencesMessage, command[0]);
                    this.renderer.ShowMessage(message);
                }
                else
                {
                    message = string.Format(Constants.OccurencesMessage, occuranses);
                    this.renderer.ShowMessage(message);
                }
            }
            else
            {
                this.ExecuteCommand(command);
            }
        }

        private void FinishTheGame()
        {
            string message;

            if (this.gameStrategy.HelpUsed)
            {
                message = string.Format(Constants.WinWithHelpMessage, this.player.Mistakes);
                this.renderer.ShowMessage(message);
            }
            else
            {
                if (this.scoreBoard.GetWorstTopScore() <= this.player.Mistakes)
                {
                    message = string.Format(Constants.LowScoreMessage, this.player.Mistakes);
                    this.renderer.ShowMessage(message);
                }
                else
                {
                    string name = this.renderer.GetPlayerName();
                    this.scoreBoard.AddNewScore(name, this.player.Mistakes);
                    this.renderer.ShowScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                }
            }

            this.gameStrategy.ReSet();
        }

        private void ExecuteCommand(string command)
        {
            string message;

            switch (command)
            {
                case "top":
                    {
                        this.renderer.ShowScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                        return;
                    }
                case "help":
                    {
                        char revealedLetter = this.gameStrategy.RevealALetter();
                        message = string.Format(Constants.UsedHelpMessage, revealedLetter);
                    }
                    break;
                case "restart":
                    {
                        this.scoreBoard.ReSet();
                        this.gameStrategy.ReSet();
                        message = Constants.WelcomeMessage;
                    }
                    break;
                case "exit":
                    {
                        message = Constants.GoodbyeMessage;
                    }
                    break;
                default:
                    {
                        message = Constants.IncorrectCommandMessage;
                    }
                    break;
            }

            this.renderer.ShowMessage(message);
        }
    }
}