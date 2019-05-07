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
    public class Player
    {
        public Bullet bullet;
        public Rectangle rectangle;
        public Canvas canvas;
        public Point pos = new Point(285, 500);
        int pSpeed = 4;
        public Player(Rectangle r, Canvas c)
        {
            rectangle = r;
            canvas = c;
            rectangle.Height = 30;
            rectangle.Width = 30;
            rectangle.Fill = Brushes.Blue;
            c.Children.Add(r);
        }

        public void pMovement()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (pos.Y >= 0)
                {
                    pos.Y -= pSpeed;
                }
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                if (pos.Y <= 530)
                {
                    pos.Y += pSpeed;
                }
            }
            else if (Keyboard.IsKeyDown(Key.Left))
            {
                if (pos.X >= 5)
                {
                    pos.X -= pSpeed;
                }

            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                if (pos.X <= 550)
                {
                    pos.X += pSpeed;
                }
            }
            Canvas.SetLeft(rectangle, pos.X);
            Canvas.SetTop(rectangle, pos.Y);
            
        }
         
        public void pCombat()
        {
             if (Keyboard.IsKeyDown(Key.Space))
             { 
                bullet = new Bullet(canvas);
                bullet.bFire();
                // bullet.bMove();
                isFired = true;
             }
        }       

    }
}
