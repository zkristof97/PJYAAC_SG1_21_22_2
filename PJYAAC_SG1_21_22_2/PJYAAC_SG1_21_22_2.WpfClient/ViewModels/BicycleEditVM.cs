using GalaSoft.MvvmLight;
using PJYAAC_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.WpfClient.ViewModels
{
    public class BicycleEditVM : ViewModelBase
    {
        private BicycleModel editableBicycle;

        public BicycleModel EditableBicycle
        {
            get { return editableBicycle; }
            set { Set(ref editableBicycle, value); }
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { Set(ref isEnabled, value); }
        }
    }
}
