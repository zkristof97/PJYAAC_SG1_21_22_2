using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string[]>(this
                , "OperationResult"
                , (msgs) => MessageBox.Show(string.Join(Environment.NewLine, msgs), "Infó"
                , MessageBoxButton.OK
                , MessageBoxImage.Information));
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
