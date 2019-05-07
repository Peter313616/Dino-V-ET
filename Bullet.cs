using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ETstrikesBack
{
    public class Bullet
    {
        public Player player;
        //public Alien alien;
        public Rectangle bullet;
        public Canvas canvas;
        public Point bPoint = new Point();
        public DispatcherTimer bTimer = new DispatcherTimer();
        public Rectangle tempR = new Rectangle();
        int bSpeed = 8;

        public Bullet(
            Canvas c)
        {
            //bullet = r;
            canvas = c;
            
           // bTimer.Tick += BTimer_Tick;
            //bTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            //bTimer.Start();
        }

        

        public void bFire()
        {
            // canvas.Children.Add(bullet);
            player = new Player(canvas);
            bullet = new Rectangle();
            bullet.Height = 20;
            bullet.Width = 10;
            bullet.Fill = Brushes.Black;
            bPoint.X = player.pos.X;
            bPoint.Y = player.pos.Y + 3;
            canvas.Children.Add(bullet);
        }
        public void bMove()
        {
            bPoint.Y = bPoint.Y - 5;
            Canvas.SetTop(bullet, bPoint.Y);
        }

        /*public void BTimer_Tick(object sender, EventArgs e)
        {
            
        }*/

    }
}
