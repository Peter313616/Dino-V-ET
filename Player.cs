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
        }
    }
}
