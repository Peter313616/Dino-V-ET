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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Rectangle r = new Rectangle();
            BitmapImage bi = new BitmapImage(new Uri("MainWindowET.png", UriKind.Relative));
            ImageBrush img = new ImageBrush(bi);
            r.Fill = img;
            r.Height = 600;
            r.Width = 600;
            canvas.Children.Insert(0, r);

        
            Rectangle rect = new Rectangle();
            BitmapImage bit = new BitmapImage(new Uri("ETCharacter.png", UriKind.Relative));
            ImageBrush image = new ImageBrush(bit);
            rect.Fill = image;
            rect.Height = 300;
            rect.Width = 300;
            Canvas.SetLeft(rect, 150);
            Canvas.SetBottom(rect, 150);
            canvas.Children.Add(rect);
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnScores_Click(object sender, RoutedEventArgs e)
        {
            highscores = new HighScores();
            highscores.getHighScores();
            highscores.showHighScores();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();
            g.ShowDialog();
        }
        private void btnPuP_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();
            g.pToggle();
        }
    }
}
