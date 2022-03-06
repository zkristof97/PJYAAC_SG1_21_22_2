using GalaSoft.MvvmLight;
using PJYAAC_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.WpfClient
{
    public class BicycleVM : ViewModelBase
    {
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

        public BicycleVM()
        {
            Bikes = new ObservableCollection<BicycleModel>();

            if(IsInDesignMode)
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
               , false
               , "red"
               , "Cube"
               , "Mountain Bike");

            var bike3 = new BicycleModel(
                3
               , DateTime.Now
               , 800000
               , false
               , false
               , "Blue"
               , "Cube"
               , "Mountain Bike");

            Bikes.Add(bike1);
            Bikes.Add(bike2);
            Bikes.Add(bike3);

            Bicycle = bike2;
            }
        }
    }
}
