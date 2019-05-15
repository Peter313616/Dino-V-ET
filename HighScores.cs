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
    class HighScores
    {
        int[] Scores;

        public HighScores()
        {
            Scores = new int[5];

            for (int i = 0; i < Scores.Length; i++)
            {
                Scores[i] = 0;
            }
        }

        public void addHighScore(int s)
        {
            int tempScore = 0;
    
            for (int i = 0; i < Scores.Length; i++)
            {
                if (Scores[i] <= s)
                {
                    tempScore = Scores[i];
                    Scores[i] = s;
                    s = tempScore;
                }
            }
            try
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter("scores.txt");
                writer.Write(showHighScores());
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string showHighScores()
        {
            string output = "";
            for (int i = 0; i < Scores.Length; i++)
            {
                output += Scores[i].ToString() + "\r\n";
            }
            MessageBox.Show(output);
            return output;
        }
        public void getHighScores()
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader("scores.txt");
                int counter = 0;
                while (!reader.EndOfStream)
                {
                    if (counter < Scores.Length)
                    {
                        int.TryParse(reader.ReadLine(), out Scores[counter]);
                        counter++;
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error: " + ex.Message + "\n" + "Don't worry, I got this");
            }
        }
    }
}
