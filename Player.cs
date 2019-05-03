using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ETstrikesBack
{
    public class Player

    {
        Canvas canvas;
        Window window;
        public Rectangle rectangle;
        public Point pos = new Point(100, 100);
        public Player(Canvas c, Window w)
        {
            canvas = c;
            window = w;
            rectangle = new Rectangle();
            rectangle.Height = 30;
            rectangle.Width = 30;
            rectangle.Fill = Brushes.Blue;
            Canvas.SetLeft(rectangle, pos.X);
            Canvas.SetTop(rectangle, pos.Y);
            canvas.Children.Add(rectangle);
        }
        public void pMovement(Key key)
        {
            if(key == Key.Up)
            {
                pos.Y -= 30;
            }
            if(key == Key.Down)
            {
                pos.Y += 30;
            }
            if(key == Key.Left)
            {
                pos.X -= 30;
            }
            if(key == Key.Right)
            {
                pos.X += 30;
            }
            Canvas.SetLeft(rectangle, pos.X);
            Canvas.SetTop(rectangle, pos.Y);
        }
    }
}
