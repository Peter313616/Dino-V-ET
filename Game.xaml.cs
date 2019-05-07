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

namespace ETstrikesBack
{
    public enum GameState { GameOn, LevelUp, GameOver }
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public GameState gameState;
        //public DispatcherTimer timer;
        Rectangle test = new Rectangle();
        Point tempPoint = new Point();
        System.Windows.Threading.DispatcherTimer timer;
        Player player;
        Alien alien;

        public Game()
        {
            InitializeComponent();
            gameState = GameState.LevelUp;
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick +=  Timer_Tick;
            timer.Interval = new TimeSpan(0,0,0, 0, 1000 / 60);
            timer.Start();
            player = new Player(canvas);
            player.pDraw();
            player.pMovement();
            alien = new Alien(canvas);
            alien.Draw();
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            player.pMovement();
            alien.eMovement();
        }
    }
}
