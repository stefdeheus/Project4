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
    /// Interaction logic for SecondBar.xaml
    /// </summary>
    public partial class SecondBar : Window
    {
        public static string deelGemeente;
        
        public SecondBar()
        {
            if (deelGemeente == null)
            {
                deelGemeente = "Feijenoord";
            }
            
            InitializeComponent();
            
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Feijenoord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Centrum_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Charlois_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Delfshaven_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Hilligersberg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Hoek_van_Holland_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Hoogvliet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Kralingen_Crooswijk_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Nieuw_Mathenesse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Noord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Overschie_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Pernis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Prins_Alexander_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Rivium_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Rotterdam_Noord_West_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Schieveen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Spaanse_Polder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Vondelingsplaat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }

        private void Waalhaven_Eemhaven_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            deelGemeente = item.Content.ToString();
            var newWindow = new SecondBar();
            newWindow.Show();
            this.Close();
        }
    }
}
