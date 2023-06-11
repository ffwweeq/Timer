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

namespace Timer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> hours = new List<string>();          
        List<string> minutes = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i <= 23; i++)
                hours.Add(string.Format("{0:00}", i));
            for (int i = 0; i <= 59; i++)
                minutes.Add(string.Format("{0:00}", i));

            cmbHour.ItemsSource = hours;
            cmbMin.ItemsSource = minutes;
        }
    }
}
