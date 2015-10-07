using System.Windows;
using System.Windows.Controls;

using HangmanGame.HangmanGame;
using HangmanGame.HangmanGame.Contracts;

namespace HangmanGameWPF
{
    public partial class MainWindow : Window
    {
        private IEngine engine;

        public MainWindow()
        {
            InitializeComponent();
            this.gridPlayField.Visibility = Visibility.Hidden;
            this.Results.Visibility = Visibility.Hidden;
            this.Menu.Visibility = Visibility.Hidden;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            var playerName = this.PlayerName.Text;
            Game game = new WPFGame();
            game.Initialize();
            this.engine = game.Engine;
            this.engine.Player.Name = playerName;
            var renderer = this.engine.Renderer as WPFRenderer;
            renderer.MainWindow = this;
            this.InputGrid.Visibility = Visibility.Hidden;
            this.gridPlayField.Visibility = Visibility.Visible;
            this.Menu.Visibility = Visibility.Visible;
            game.Start();
        }

        private void ButtonKeyBoard_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            this.engine.ReactToPlayerAction(button.Content.ToString().ToLower());

            bool isGameOver = this.engine.CheckGameOverCondition();
            bool isWordGuessed = this.engine.CheckWinningCondition();

            if (isGameOver)
            {
                this.engine.Renderer.ShowMessage(Constants.GameOverMessage);
                this.engine.FinishGame();
            }

            if (isWordGuessed)
            {
                this.engine.FinishGame();
            }
        }
    }
}
