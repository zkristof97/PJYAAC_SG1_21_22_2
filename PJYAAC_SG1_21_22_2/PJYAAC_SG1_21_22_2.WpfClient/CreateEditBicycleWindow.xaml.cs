using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using PJYAAC_SG1_21_22_2.WpfClient.Models;
using PJYAAC_SG1_21_22_2.WpfClient.ViewModels;

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for CreateEditBicycleWindow.xaml
    /// </summary>
    public partial class CreateEditBicycleWindow : Window
    {
        private BicycleEditVM vm;
        private bool isEnabled;
        public BicycleModel Bicycle { get; private set; }
        
        public CreateEditBicycleWindow(BicycleModel? bicycle, bool isEnabled = true)
        {
            InitializeComponent();

            Bicycle = bicycle != null ? (BicycleModel)bicycle.Clone() : new BicycleModel();
            this.isEnabled = isEnabled;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            vm = (BicycleEditVM)Resources["VM"];
            vm.EditableBicycle = Bicycle;
            vm.IsEnabled = isEnabled;
        }
    }
}
