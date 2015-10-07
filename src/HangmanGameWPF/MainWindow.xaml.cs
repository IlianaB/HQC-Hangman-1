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
        }

        private void ButtonKeyBoard_Click(object sender, RoutedEventArgs e)
        {
        }

        private void EnterScore(object sender, RoutedEventArgs e)
        {
        }
    }
}
