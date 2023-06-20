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

namespace Timer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> hours = new List<string>();          
        List<string> minutes = new List<string>();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i <= 23; i++)
                hours.Add(string.Format("{0:00}", i));
            for (int i = 0; i <= 59; i++)
                minutes.Add(string.Format("{0:00}", i));

            cmbHour.ItemsSource = hours;
            cmbMin.ItemsSource = minutes;

            timer.Interval = TimeSpan.FromSeconds(1);   
            timer.Tick += new EventHandler(timer_tick); 
            timer.Start(); 
        }
        private void timer_tick(object sender, EventArgs e)
        {

            txtTime.Text = DateTime.Now.ToString("HH:mm:ss");   
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");  
            txtWeekDay.Text = DateTime.Now.ToString("dddd");     

        }

        string strSelectTime = "";
        DispatcherTimer timerAlert = new DispatcherTimer();
        private void timerAlert_tick(object sender, EventArgs e)
        {

            timerAlert.Interval = TimeSpan.FromSeconds(1);
            timerAlert.Tick += new EventHandler(timerAlert_tick);

            if (strSelectTime == DateTime.Now.ToString("HH:mm"))
            {
                meSound.LoadedBehavior = MediaState.Play;
                timerAlert.Stop();
            }
        }

        private void btnSetAlert_Click(object sender, RoutedEventArgs e)
        {
            timerAlert.Start(); 
            btnSetAlert.IsEnabled = false;
            btnCancelAlert.IsEnabled = true;
            strSelectTime = cmbHour.SelectedItem + ":" + cmbMin.SelectedItem; 
        }

        private void btnCancelAlert_Click(object sender, RoutedEventArgs e)
        {
            meSound.LoadedBehavior = MediaState.Stop;
            timerAlert.Stop(); 
            btnSetAlert.IsEnabled = true;
            btnCancelAlert.IsEnabled = false;
        }
        private void meSound_MediaEnded(object sender, RoutedEventArgs e)
        {
             meSound.Position = new TimeSpan(0, 0, 1); 
             meSound.LoadedBehavior = MediaState.Play;
        }

    }
}
