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

namespace EE3250_Assignment_1_3921 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {

        private readonly DispatcherTimer _timer;
        public MainWindow() {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTimeText.Text = DateTime.Now.ToString("hh:mm tt");
        }
    }
}
