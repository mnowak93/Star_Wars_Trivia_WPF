using System.Windows;

namespace SWTrivia
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            OpenGame(5);
        }        

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            OpenGame(10);
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            OpenGame(15);
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            OpenGame(20);
        }

        private void OpenGame(int x)
        {
            Game g = new Game(x);
            g.Show();
            Close();
        }
    }
}