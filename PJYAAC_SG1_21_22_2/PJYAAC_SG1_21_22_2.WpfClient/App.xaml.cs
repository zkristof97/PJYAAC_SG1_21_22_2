using _04LayeredCRUD.Infrastructure;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using PJYAAC_SG1_21_22_2.WpfClient.BL.Implementation;
using PJYAAC_SG1_21_22_2.WpfClient.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);

            SimpleIocAsServiceLocator.Instance.Register<IBicycleHandlerService, BicycleHandlerService>();
            SimpleIocAsServiceLocator.Instance.Register<IBicycleEditorService, BicycleEditorService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
    }
}
