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
    class Alien
    {
        public Rectangle[] sprites = new Rectangle[15];
        public int enemyCount = 15;
        double enemySpeed = 1;
        Canvas canvas;
        bool IsRight = true;

        public Rectangle bullet;
        public Point bPoint = new Point();
        public Point[] enemyPos = new Point[15];
        bool isFired = false;
        Random random = new Random();

        public Alien (Canvas c)
        {
            canvas = c;
        }

        public void Draw()
        {
            int counter = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    sprites[counter] = new Rectangle();
                    sprites[counter].Height = 30;
                    sprites[counter].Width = 40;
                    sprites[counter].Fill = Brushes.Black;
                    enemyPos[counter].X = x * 70 + 72;
                    enemyPos[counter].Y = y * 50 + 20;
                    Canvas.SetLeft(sprites[counter], enemyPos[counter].X);
                    Canvas.SetTop(sprites[counter], enemyPos[counter].Y);
                    canvas.Children.Add(sprites[counter]);
                    counter++;
                }
            }
        }

        public void eMovement()
        {
            if (enemyPos.Max(enemyPos => enemyPos.X) > 545)
            {
                IsRight = false;
                for (int i = 0; i < enemyCount; i++)
                {
                    enemyPos[i].Y += 20;
                    Canvas.SetTop(sprites[i], enemyPos[i].Y);
                }
                enemySpeed += .25;
            }
            else if (enemyPos.Min(enemyPos => enemyPos.X) < 0)
            {
                IsRight = true;
                for (int i = 0; i < enemyCount; i++)
                {
                    enemyPos[i].Y += 20;
                    Canvas.SetTop(sprites[i], enemyPos[i].Y);
                }
                enemySpeed += .25;
            }

            if (IsRight)
            {
                for (int i = 0; i < enemyCount; i ++)
                {
                    enemyPos[i].X += enemySpeed;
                    Canvas.SetLeft(sprites[i], enemyPos[i].X);
                }
            }
            else
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    enemyPos[i].X -= enemySpeed;
                    Canvas.SetLeft(sprites[i], enemyPos[i].X);
                }
            }

        }

        public void eCombat()
        {
            if (isFired == false)
            {
                int pickColumn = random.Next(0, 5);
                bullet = new Rectangle();
                bullet.Height = 20;
                bullet.Width = 10;
                bullet.Fill = Brushes.Red;
                for (int i = pickColumn; i != pickColumn - 1; i++)
                {
                    if (i == 5)
                    {
                        i = 0;
                    }
                    if (sprites[i + 10].Visibility != Visibility.Collapsed)
                    {
                        bPoint.X = enemyPos[i + 10].X + 15;
                        bPoint.Y = enemyPos[i + 10].Y + 30;
                        Canvas.SetTop(bullet, bPoint.Y);
                        Canvas.SetLeft(bullet, bPoint.X);
                        i = pickColumn - 2;
                    }
                    else if (sprites[i + 5].Visibility != Visibility.Collapsed)
                    {
                        bPoint.X = enemyPos[i + 5].X + 15;
                        bPoint.Y = enemyPos[i + 5].Y + 30;
                        Canvas.SetTop(bullet, bPoint.Y);
                        Canvas.SetLeft(bullet, bPoint.X);
                        i = pickColumn - 2;
                    }
                    else if (sprites[i].Visibility != Visibility.Collapsed)
                    {
                        bPoint.X = enemyPos[i].X + 15;
                        bPoint.Y = enemyPos[i].Y + 30;
                        Canvas.SetTop(bullet, bPoint.Y);
                        Canvas.SetLeft(bullet, bPoint.X);
                        i = pickColumn - 2;
                    }
                }
                canvas.Children.Add(bullet);
                isFired = true;
            }
            else if (isFired == true)
            {
                if (bPoint.Y > 570)
                {
                    canvas.Children.Remove(bullet);
                    isFired = false;
                }
                bPoint.Y += 8;
                Canvas.SetTop(bullet, bPoint.Y);
            }
        }
    }
}
