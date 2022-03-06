using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PJYAAC_SG1_21_22_2.WpfClient.BL.Interfaces;
using PJYAAC_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    public class BicycleVM : ViewModelBase
    {
        private readonly IBicycleHandlerService _bicycleHandlerService;
        private BicycleModel bicycle;

        public BicycleModel Bicycle
        {
            get { return bicycle; }
            set { Set(ref bicycle, value); }
        }

        private ObservableCollection<BicycleModel> bikes;

        public ObservableCollection<BicycleModel> Bikes
        {
            get { return bikes; }
            set { Set(ref bikes, value); }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public BicycleVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IBicycleHandlerService>()) { }

        public BicycleVM(IBicycleHandlerService bicycleHandlerService)
        {
            _bicycleHandlerService = bicycleHandlerService;
            Bikes = new ObservableCollection<BicycleModel>();

            if (IsInDesignMode)
            {

                var bike1 = new BicycleModel(
                1
                , DateTime.Now
                , 100000
                , false
                , false
                , "white"
                , "Specialized"
                , "Trekking");

                var bike2 = new BicycleModel(
                    2
                   , DateTime.Now
                   , 200000
                   , false
                   , true
                   , "red"
                   , "Cube"
                   , "Mountain Bike");

                var bike3 = new BicycleModel(
                    3
                   , DateTime.Now
                   , 800000
                   , true
                   , false
                   , "Blue"
                   , "Cube"
                   , "Mountain Bike");

                Bikes.Add(bike1);
                Bikes.Add(bike2);
                Bikes.Add(bike3);

                Bicycle = bike2;
            }

            AddCommand = new RelayCommand(() => _bicycleHandlerService.AddBicycle(Bikes), true);
            EditCommand = new RelayCommand(() => _bicycleHandlerService.EditBicycle(Bicycle), true);
            DeleteCommand = new RelayCommand(() => _bicycleHandlerService.DeleteBicycle(Bikes, Bicycle), true);
        }
    }
}
