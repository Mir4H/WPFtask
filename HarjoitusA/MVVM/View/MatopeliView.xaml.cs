using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WPFharjoituksia.MVVM.View
{
    /// <summary>
    /// Interaction logic for MatoPeliView.xaml
    /// </summary>
    public partial class MatopeliView : UserControl
    {
        private List<Point> snakePoints = new List<Point>();
        private Point bonusPoints = new Point();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private string direction = "";
        bool start;
        int score = 0;
        Random random = new Random();
        private int length = 5;
        DispatcherTimer speed = new DispatcherTimer();
        int highest = 0;


        public MatopeliView()
        {
            InitializeComponent();

            Ylos.Visibility = Visibility.Hidden;
            Alas.Visibility = Visibility.Hidden;
            Vasen.Visibility = Visibility.Hidden;
            Oikea.Visibility = Visibility.Hidden;
            info.Visibility = Visibility.Hidden;
            highest = Properties.Settings.Default.highscore;
            highscore.Text = Properties.Resource.High + highest;

        }

        private void StartNew()
        {
            aloita.Visibility = Visibility.Hidden;
            speed.Tick += new EventHandler(timer_Tick);
            speed.Interval = new TimeSpan(470000);
            speed.Start();
            currentPosition = startingPoint;
            paintSnake(startingPoint);
            paintBonus(0);
        }

        private void paintSnake(Point currentposition)
        {

            Ellipse mato = new Ellipse();
            mato.Fill = Brushes.Beige;
            mato.Width = 10;
            mato.Height = 10;

            Canvas.SetTop(mato, currentposition.Y);
            Canvas.SetLeft(mato, currentposition.X);

            int count = matopeli.Children.Count;
            matopeli.Children.Add(mato);
            snakePoints.Add(currentposition);

            if (count > length)
            {
                matopeli.Children.RemoveAt(count - length);
                snakePoints.RemoveAt(count - length);
            }
        }

        private void paintBonus(int index)
        {

            Point bonusPoint = new Point(random.Next(10, (Convert.ToInt32(matopeli.ActualWidth) - 10)), random.Next(10, (Convert.ToInt32(matopeli.ActualHeight) - 10)));
            bonusPoints = bonusPoint;

            Rectangle ruoka = new Rectangle();
            ruoka.Fill = Brushes.PeachPuff;
            ruoka.Width = 10;
            ruoka.Height = 10;

            Canvas.SetTop(ruoka, bonusPoint.Y);
            Canvas.SetLeft(ruoka, bonusPoint.X);

            matopeli.Children.Insert(index, ruoka);
        }


        private void Ylos_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            direction = "ylos";

        }

        private void Oikea_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            direction = "oikea";
        }

        private void Vasen_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            direction = "vasen";
        }

        private void Alas_Click(object sender, RoutedEventArgs e)
        {
            start = true;
            direction = "alas";
        }


        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
                switch (e.Key)
                {
                    case (Key.Up):
                        start = true;
                    if (direction != "alas")
                            direction = "ylos";
                        this.contentControl.Focus();
                        break;
                    case (Key.Down):
                        start = true;
                    if (direction != "ylos")
                        direction = "alas";
                        this.contentControl.Focus();
                        break;
                    case (Key.Left):
                        start = true;
                    if (direction != "oikea")
                        direction = "vasen";
                        this.contentControl.Focus();
                        break;
                    case (Key.Right):
                        start = true;
                    if (direction != "vasen")
                        direction = "oikea";
                        this.contentControl.Focus();
                        break;
                }
        }
       


        private void timer_Tick(object sender, EventArgs e)
        {
            if (start == true) {
                switch (direction)
                {
                    case ("alas"):
                        currentPosition.Y += 10;
                        paintSnake(currentPosition);
                        break;
                    case ("ylos"):
                        currentPosition.Y -= 10;
                        paintSnake(currentPosition);
                        break;
                    case ("vasen"):
                        currentPosition.X -= 10;
                        paintSnake(currentPosition);
                        break;
                    case ("oikea"):
                        currentPosition.X += 10;
                        paintSnake(currentPosition);
                        break;
                }
            }

            for (int x = 0; x < (snakePoints.Count - 20); x++)
            {
                Point point = new Point(snakePoints[x].X, snakePoints[x].Y);
                if ((Math.Abs(point.X - currentPosition.X) < 10) &
                     (Math.Abs(point.Y - currentPosition.Y) < 10))
                {
                    GameOver();
                    break;
                }
            }

            var hitX = Math.Abs(bonusPoints.X - currentPosition.X);
            var hitY = Math.Abs(bonusPoints.Y - currentPosition.Y);

            if (hitX < 10 & hitY < 10)
            {
                length += 5;
                score += 10;
                matopeli.Children.RemoveAt(0);
                speed.Start();
                paintBonus(0);
            }

            if ((currentPosition.X > matopeli.ActualWidth - 10) || (currentPosition.Y > matopeli.ActualHeight - 10) || (currentPosition.Y < 0) || (currentPosition.X < 0))
                    GameOver();
        }

        private void GameOver()
        {
            speed.Tick -= timer_Tick;
            start = false;
            direction = "";
            length = 5;
            snakePoints.Clear();
            matopeli.Children.Clear();
            aloita.Visibility = Visibility.Visible;
            Ylos.Visibility = Visibility.Hidden;
            Alas.Visibility = Visibility.Hidden;    
            Vasen.Visibility = Visibility.Hidden;   
            Oikea.Visibility = Visibility.Hidden;
            info.Visibility = Visibility.Hidden;
            tulos.Visibility = Visibility.Visible;
            tulos.Text = Properties.Resource.GameOver + " " + score;
            if (score > highest)
            {
                Properties.Settings.Default.highscore = score;
                Properties.Settings.Default.Save();
            }
            score = 0;
        }

        private void aloita_Click(object sender, RoutedEventArgs e)
        {
            highscore.Text = Properties.Resource.High + Properties.Settings.Default.highscore;
            Ylos.Visibility = Visibility.Visible;
            Alas.Visibility = Visibility.Visible;
            Vasen.Visibility = Visibility.Visible;
            Oikea.Visibility = Visibility.Visible;
            info.Visibility = Visibility.Visible;
            tulos.Visibility = Visibility.Hidden;
            StartNew();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.contentControl.Focus();
        }
    }
}
