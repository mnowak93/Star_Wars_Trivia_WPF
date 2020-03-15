using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Timers;

namespace SWTrivia
{
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        QuestionList lst = new QuestionList(@"questions.csv");
        int score = 0;
        int rounds = 0;
        int maxRounds = 0;
        Random rnd = new Random();
        Question qst = new Question();
        private Timer timer;

        public Game(int max)
        {
            qst = lst.QLst[rnd.Next(0, lst.QLst.Count())];
            maxRounds = max;
            timer = new Timer { Interval = 500 };
            InitializeComponent();            
            txtScore.Text = score.ToString();
            txtNumber.Text = (rounds + 1).ToString();
            txtQuestion.Text = qst.QuestionTxt;
        }

        private void btnA_Click(object sender, RoutedEventArgs e)
        {
            ClickFunction("A", btnA);
        }

        private void btnb_Click(object sender, RoutedEventArgs e)
        {
            ClickFunction("B", btnb);
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            ClickFunction("C", btnC);
        }

        private void btnD_Click(object sender, RoutedEventArgs e)
        {
            ClickFunction("D", btnD);
        }

        private void ClickFunction(string anw, Button btn)
        {
            rounds++;
            qst.IsUsed();
            if (qst.CheckAnswer(anw) == true)
            {
                score++;
                txtScore.Text = score.ToString();
                ColorForTime(btn, 152, 251, 152);
            }
            else
            {
                ColorForTime(btn, 205, 92, 92);
            }
            if (rounds < maxRounds)
            {
                while (qst.Used == true)
                {
                    qst = lst.QLst[rnd.Next(0, lst.QLst.Count())];
                }
                txtQuestion.Text = qst.QuestionTxt;
                txtNumber.Text = (rounds + 1).ToString();
            }
            else
            {
                Menu men = new Menu(score, maxRounds);
                Close();
                men.Show();
            }
        }

        private void HandleTimerTick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            timer.Stop();
            btnA.Dispatcher.BeginInvoke((Action)delegate ()
            {
                btnA.ClearValue(Button.BackgroundProperty);
            });

            btnb.Dispatcher.BeginInvoke((Action)delegate ()
            {
                btnb.ClearValue(Button.BackgroundProperty);
            });

            btnC.Dispatcher.BeginInvoke((Action)delegate ()
            {
                btnC.ClearValue(Button.BackgroundProperty);
            });

            btnD.Dispatcher.BeginInvoke((Action)delegate ()
            {
                btnD.ClearValue(Button.BackgroundProperty);
            });
        }

        private void ColorForTime(Button bt, byte r, byte g, byte b)
        {
            timer.Elapsed += HandleTimerTick;
            bt.Background = new SolidColorBrush(Color.FromRgb(r,g,b));
            timer.Stop();
            timer.Start();
        }
    }
}