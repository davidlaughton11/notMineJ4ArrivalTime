/*David Laughton
 * june 6th 2019
 * Rush hour problem
 */

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

namespace CulminatingProblemJ4ArrivalTime
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            string startTime = TimeInput.Text;
            string[] splitHHMM = startTime.Split(':');
            int h, m, t;
            int.TryParse(splitHHMM[0], out h);
            int.TryParse(splitHHMM[1], out m);                     
            
            //to get the time in minutes
            t = h * 60 + m;
            //int i equals the max amount of time travel can take
            //adding to t because that is how the travel works adding minutes
            for (int i = 240; i > 0; t++)
            {
                //an if and else if statement to keep the time twice as slow if they are in 
                if (t >= 7 * 60 && t < 10 * 60)
                {
                    i--;
                }
                else if (t >= 15 * 60 && t < 19 * 60)
                {
                    i--;
                }
                //else for if the travel is not in rush hour
                else
                {
                    i -= 2;
                }
            }
            //the minutes and hours after the time is adjusted
            int MM = t % 60;
            int HH = t / 60 % 24;
            //outputing the proper arrival time
            if (MM < 10)
            {
                lblOutput.Content = HH + ":" + MM + "0";
            }
            else
            {
                lblOutput.Content = HH + ":" + MM;
            }
        }
    }
}
