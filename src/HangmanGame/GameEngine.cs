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
            string message = Constants.WELCOME_MESSAGE;
            this.renderer.ShowMessage(message);

            do
            {
                this.renderer.ShowCurrentProgress(this.gameStrategy.GuessedLetters);
                
                if (this.gameStrategy.isOver())
                {
                    this.FinishTheGame();
                }
                else
                {
                    command = this.renderer.ReadCommand();
                    this.ReactToPlayerAction(command);
                }
            } while (command != "exit");
        }

        private void ReactToPlayerAction(string command)
        {
            string message = string.Empty;

            if (command.Length == 1)
            {
                int occuranses = this.gameStrategy.NumberOccuranceOfLetter(command[0]);

                if (occuranses == 0)
                {
                    this.player.IncreaseMistakes();
                    message = string.Format(Constants.NO_OCCURENCES_MESSAGE, command[0]);
                    this.renderer.ShowMessage(message);
                }
                else
                {
                    message = string.Format(Constants.OCCURENCES_MESSAGE, occuranses);
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
            string message = string.Empty;

            if (this.gameStrategy.HelpUsed)
            {
                message = string.Format(Constants.WIN_WITH_HELP_MESSAGE, this.player.Mistakes);
                this.renderer.ShowMessage(message);
            }
            else
            {
                if (this.scoreBoard.GetWorstTopScore() <= this.player.Mistakes)
                {
                    message = string.Format(Constants.LOW_SCORE_MESSAGE, this.player.Mistakes);
                    this.renderer.ShowMessage(message);
                }
                else
                {
                    string name = this.renderer.getPlayerName();
                    this.scoreBoard.AddNewScore(name, this.player.Mistakes);
                    this.renderer.ShowScoreBoardResults(this.scoreBoard.IsEmpty, this.scoreBoard.ScoreNames, this.scoreBoard.Mistakes);
                }
            }

            this.gameStrategy.ReSet();
        }

        private void ExecuteCommand(string command)
        {
            var message = string.Empty;

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
                        message = string.Format(Constants.USED_HELP_MESSAGE, revealedLetter);
                    }
                    break;
                case "restart":
                    {
                        this.scoreBoard.ReSet();
                        this.gameStrategy.ReSet();
                        message = Constants.WELCOME_MESSAGE;
                    }
                    break;
                case "exit":
                    {
                        message = Constants.GOODBYE_MESSAGE;
                    }
                    break;
                default:
                    {
                        message = Constants.INCORRECT_COMMAND_MESSAGE;
                    }
                    break;
            }

            this.renderer.ShowMessage(message);
        }
    }
}

