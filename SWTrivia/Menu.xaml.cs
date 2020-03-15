using System.Windows;

namespace SWTrivia
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu(int s, int max)
        {
            InitializeComponent();
            if (s == max)
            {
                txtScore.Text = "Congratulations! You score max! |-o-|";
            }
             else
            {
              txtScore.Text = "Your score: " + s.ToString();
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow g = new MainWindow();
            g.Show();
            Close();
        }
    }
}
