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
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnScores_Click(object sender, RoutedEventArgs e)
        {

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
