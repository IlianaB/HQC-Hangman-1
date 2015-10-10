using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hangman.Logic.Engines;
using Hangman.Logic.Games;

namespace Hangman.WPF.UI
{
    public partial class MainWindow : Window
    {
        private IEngine engine;

        public MainWindow()
        {
            this.InitializeComponent();
            this.gridPlayField.Visibility = Visibility.Hidden;
            this.Results.Visibility = Visibility.Hidden;
            this.Menu.Visibility = Visibility.Hidden;
            this.HideHangman();
        }

        private void HideHangman()
        {
            this.HorizontalLine.Visibility = Visibility.Hidden;
            this.VerticalLine.Visibility = Visibility.Hidden;
            this.Rope.Visibility = Visibility.Hidden;
            this.Head.Visibility = Visibility.Hidden;
            this.Body.Visibility = Visibility.Hidden;
            this.LeftHand.Visibility = Visibility.Hidden;
            this.RightHand.Visibility = Visibility.Hidden;
            this.LeftLeg.Visibility = Visibility.Hidden;
            this.RightLeg.Visibility = Visibility.Hidden;
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            var playerName = this.PlayerName.Text;
            Game game = new WpfGame();
            game.Initialize();
            this.engine = game.Engine;
            this.engine.Player.Name = playerName;
            var renderer = this.engine.Renderer as WpfRenderer;
            renderer.MainWindow = this;
            this.InputGrid.Visibility = Visibility.Hidden;
            this.gridPlayField.Visibility = Visibility.Visible;
            this.Menu.Visibility = Visibility.Visible;
            game.Start();
        }

        private void KeyBoard_KeyDown(object sender, RoutedEventArgs e)
        {
            var eventArgs = e as KeyEventArgs;
            var key = eventArgs.Key.ToString();
            if (this.engine != null)
            {
                this.ProcessKey(key);
            }
        }

        private void ButtonKeyBoard_Click(object sender, RoutedEventArgs e)
        {
            var eventArgs = sender as Button;
            var button = eventArgs.Content.ToString();

            this.ProcessKey(button);
        }

        private void ProcessKey(string key)
        {
            this.engine.ReactToPlayerAction(key.ToLower());

            bool isGameOver = this.engine.CheckGameOverCondition();
            bool isWordGuessed = this.engine.CheckWinningCondition();

            if (isGameOver)
            {
                this.HideHangman();
                this.engine.EndLostGame();
            }

            if (isWordGuessed)
            {
                this.HideHangman();
                this.engine.EndWonGame();
            }
        }
    }
}