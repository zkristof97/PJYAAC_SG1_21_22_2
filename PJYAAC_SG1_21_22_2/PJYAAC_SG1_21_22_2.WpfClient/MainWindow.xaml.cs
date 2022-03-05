using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BicycleVM vm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateClicked(object sender, RoutedEventArgs e)
        {
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteClicked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Resources["VM"] != null)
            {
                vm = (BicycleVM)Resources["VM"];
            }
        }
    }
}
