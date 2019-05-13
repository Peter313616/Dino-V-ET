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
        public Rectangle rectangle;
        public Canvas canvas;
        public Point pos = new Point(285, 500);
        public int pSpeed = 4;
        public int Lives = 3;

        public Rectangle bullet;
        public Point bPoint = new Point(0, 0);
        public int bSpeed = 8;
        public bool isFired = false;
        public bool DidHit = false;
        public Player(Canvas c)
        {
            canvas = c;
        }

        /// <summary>
        /// 
        /// </summary>
        public void pDraw()
        {
            rectangle = new Rectangle();
            rectangle.Height = 30;
            rectangle.Width = 30;
            rectangle.Fill = Brushes.Blue;
            canvas.Children.Add(rectangle);
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
            if (Keyboard.IsKeyDown(Key.Space) && isFired == false)
            {
                bullet = new Rectangle();
                bullet.Height = 20;
                bullet.Width = 10;
                bullet.Fill = Brushes.Green;
                bPoint.X = pos.X + 10;
                bPoint.Y = pos.Y - 18;
                Canvas.SetTop(bullet, bPoint.Y);
                Canvas.SetLeft(bullet, bPoint.X);
                canvas.Children.Add(bullet);
                isFired = true;
                DidHit = false;
            }
            else if (isFired == true)
            {
                if (bPoint.Y < 0)
                {
                    canvas.Children.Remove(bullet);
                    isFired = false;
                }
                bPoint.Y -= bSpeed;
                Canvas.SetTop(bullet, bPoint.Y);
            }
        }
    }
}
