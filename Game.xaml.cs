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
using System.Windows.Navigation;
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
        System.Windows.Threading.DispatcherTimer timer;
        Player player;
        Alien alien;
        Powerup powerup;
        int respawnTimer = 0;
        bool IsDead = false;

        public Game()
        {
            InitializeComponent();
            gameState = GameState.LevelUp;
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick +=  Timer_Tick;
            timer.Interval = new TimeSpan(0,0,0, 0, 1000 / 60);
            timer.Start();
            player = new Player(canvas);
            powerup = new Powerup(canvas)
            player.pDraw();
            player.pMovement();
            alien = new Alien(canvas);
            alien.Draw();
            
            Rectangle r = new Rectangle();
            BitmapImage bi = new BitmapImage(new Uri("ETBackground.png", UriKind.Relative));
            ImageBrush img = new ImageBrush(bi);
            r.Fill = img;
            r.Height = 600;
            r.Width = 600;
            canvas.Children.Insert(0, r);
        }
        
        public void pToggle()
        {
            powerup.pUpToggle();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            player.pMovement();
            alien.eMovement();
            player.pCombat();
            alien.eCombat();
            if(powerup.toggle == true){
            powerup.pUpMovement();
            }

            if (alien.bPoint.X <= player.pos.X + 30 && alien.bPoint.X >= player.pos.X - 10
                && alien.bPoint.Y <= player.pos.Y + 30 && alien.bPoint.Y >= player.pos.Y
                && IsDead == false)
            {
                player.rectangle.Visibility = Visibility.Collapsed;
                player.Lives--;
                MessageBox.Show(player.Lives.ToString());
                IsDead = true;
            }

            if (IsDead)
            {
                respawnTimer++;
            }
            if (respawnTimer >= 20 && respawnTimer != 100)
            {
                if (respawnTimer == 20)
                {
                    player.pos.X = 285;
                    player.pos.Y = 500;
                    player.rectangle.Visibility = Visibility.Visible;
                }
                if (respawnTimer % 10 == 0)
                {
                    player.rectangle.Fill = Brushes.Blue;
                }
                else if (respawnTimer % 10 == 5)
                {
                    player.rectangle.Fill = Brushes.White;
                }
            }
            else if (respawnTimer == 100)
            {
                IsDead = false;
                respawnTimer = 0;
                player.rectangle.Fill = Brushes.Blue;
            }
            for (int i = 0; i < 15; i++)
            {
                 if (player.bPoint.X >= alien.enemyPos[i].X - 10 && player.bPoint.X <= alien.enemyPos[i].X + 39
                    && player.bPoint.Y >= alien.enemyPos[i].Y - 20 && player.bPoint.Y <= alien.enemyPos[i].Y + 30
                    && alien.sprites[i].Visibility != Visibility.Collapsed && player.DidHit == false)
                 {
                    alien.sprites[i].Visibility = Visibility.Collapsed;
                    canvas.Children.Remove(player.bullet);
                    player.DidHit = true;
                 }
            }
        
        }
    }
    
    public enum pUp { oneUp, fastShip, slowAlien, fastBullets}
    public class Powerup
    {
        
        Canvas canvas;
        public bool toggle;
        int tCounter;
        Rectangle r;
        Random random = new Random();
        int selected;
        public pUp p;
        public Powerup(Canvas c)
        {
            canvas = c;
        }

        public void pUpToggle()
        {
            if (tCounter == 0 || tCounter % 2 == 0)
            {
                toggle = true;
                tCounter++;
            }
            else
            {
                toggle = false;
                tCounter++;
            }
        }

        public void pUpMovement()
        {
            r = new Rectangle();
            r.Height = 20;
            r.Width = 30;
            selected = random.Next(1, 4);

            if (selected == 1)
            {
                p = pUp.oneUp;
            }
            else if (selected == 2)
            {
                p = pUp.fastShip;
            }
            else if (selected == 3)
            {
                p = pUp.fastBullets;
            }
            else if(selected == 4)
            {
                p = pUp.slowAlien;
            }
            
            if(p == pUp.oneUp)
            {
                //rectangle is the one up sprite
            }
            else if(p == pUp.fastShip)
            {

            }
            else if(p == pUp.fastBullets)
            {

            }
            else if(p == pUp.slowAlien)
            {

            }
            // do code here to fill rectangle with sprite when we get sprites
        }
    } 
}
