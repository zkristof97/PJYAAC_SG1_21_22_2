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
using PJYAAC_SG1_21_22_2.WpfClient.Models;

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for CreateEditBicycleWindow.xaml
    /// </summary>
    public partial class CreateEditBicycleWindow : Window
    {
        public BicycleModel Bicycle { get; private set; }
        
        public CreateEditBicycleWindow(BicycleModel? bicycle)
        {
            InitializeComponent();

            Bicycle = bicycle != null ? (BicycleModel)bicycle.Clone() : new BicycleModel();

            DataContext = Bicycle;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
