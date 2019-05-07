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
        double[] Edges = new double[2];
        bool IsRight = true;
        public Point[] enemyPos = new Point[15];

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
                    if (Edges[0] > enemyPos[counter].X)
                    {
                        Edges[0] = enemyPos[counter].X;
                    }
                    else if (Edges[1] < enemyPos[counter].X)
                    {
                        Edges[1] = enemyPos[counter].X;
                    }

                    counter++;
                }
            }
        }

        public void eMovement()
        {
            if (enemyPos.Max(enemyPos => enemyPos.X) > 550)
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
    }
}
