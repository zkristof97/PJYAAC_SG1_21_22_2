using System.Windows;

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
            var createWindow = new CreateEditBicycleWindow(null);
            createWindow.Owner = this;

            if (createWindow.ShowDialog() == true)
            {
                vm.Bikes.Add(createWindow.Bicycle);
            }
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            var editWindow = new CreateEditBicycleWindow(vm.Bicycle);
            editWindow.Owner = this;

            var editResult = editWindow.ShowDialog();

            if (editResult == true)
            {
                vm.Bicycle.DateOfPurchase = editWindow.Bicycle.DateOfPurchase;
                vm.Bicycle.Price = editWindow.Bicycle.Price;
                vm.Bicycle.IsFullSuspension = editWindow.Bicycle.IsFullSuspension;
                vm.Bicycle.IsElectric = editWindow.Bicycle.IsElectric;
                vm.Bicycle.Color = editWindow.Bicycle.Color;
                vm.Bicycle.Type = editWindow.Bicycle.Type;
                vm.Bicycle.Model = editWindow.Bicycle.Model;
            }
        }

        private void DeleteClicked(object sender, RoutedEventArgs e)
        {
            vm.Bikes.Remove(vm.Bicycle);
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
