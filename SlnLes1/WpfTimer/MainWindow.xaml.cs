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
using System.Windows.Threading;

namespace WpfTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private int count = 00;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick; // voeg methode toe aan timer
            lblCount.Content = count;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            count++;
            string minuten = Convert.ToString(count / 60).PadLeft(2,'0');
            string seconden = Convert.ToString(count % 60).PadLeft(2, '0');
            lblCount.Content = $"{minuten}:{seconden}";
            rct_Min.Height = Convert.ToInt32(minuten )*10;
            rct_Secs.Height = Convert.ToInt32(seconden);


        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            btn_start.IsEnabled = false;
            btn_stop.IsEnabled = true;
            btn_reset.IsEnabled = true;


            timer.Start(); // start de timer
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            btn_start.IsEnabled = true;
            btn_stop.IsEnabled = false;
            btn_reset.IsEnabled = true;
            timer.Stop();

        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            btn_start.IsEnabled = true;
            btn_stop.IsEnabled = false;
            btn_reset.IsEnabled = false;
            count = 0;
            timer.Stop();
        }
    }
}
