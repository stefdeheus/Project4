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
using System.Windows.Shapes;


namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new LineChart();
            newWindow.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var newerWindow = new FirstBar();
            newerWindow.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new FirstPie();
            newWindow.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SecondPie();
            newWindow.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var neWindow = new SecondBar();
            neWindow.Show();
        }
    }
}
