using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ETstrikesBack
{
    public enum GameState { GameOn, LevelUp, GameOver}
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public GameState gameState;
        public DispatcherTimer timer;
        public Rectangle test = new Rectangle();
        Point tempPoint = new Point();
        public Game()
        {
            InitializeComponent();
            gameState = GameState.LevelUp;
            timer = new DispatcherTimer();

            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1000 / 10);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           if(gameState == GameState.LevelUp)
           {
                /*test.Fill = Brushes.Blue;
                test.Height = 50;
                test.Width = 50;
                canvas.Children.Add(test);*/
           }
        }

        private void key(object sender, KeyEventArgs e)
        {

        }
    }
}
