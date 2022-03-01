using GalaSoft.MvvmLight;
using PJYAAC_SG1_21_22_2.Models.Entities;
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
        private Bicycle bicycle;

        public Bicycle Bicycle
        {
            get { return bicycle; }
            set { Set(ref bicycle, value); }
        }

        public ObservableCollection<Bicycle> Bikes { get; set; }

        public BicycleVM()
        {
            Bikes = new ObservableCollection<Bicycle>();
            
            if(IsInDesignMode)
            {
                var bicycle = new Bicycle()
                {
                    Id = 10
                    , Color = "Fehér"
                    , DateOfPurchase = DateTime.Now
                    , IsElectric = false
                    , IsFullSuspension = true
                    , Model = "Specialized"
                    , Price = 50
                    , Type = "Trekking"
                };

                Bikes.Add(bicycle);
                Bikes.Add(bicycle);
                Bikes.Add(bicycle);
            }
        }
    }
}
