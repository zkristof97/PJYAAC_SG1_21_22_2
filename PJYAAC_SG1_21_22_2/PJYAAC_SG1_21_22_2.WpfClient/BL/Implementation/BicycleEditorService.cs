using PJYAAC_SG1_21_22_2.WpfClient.BL.Interfaces;
using PJYAAC_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.WpfClient.BL.Implementation
{
    public class BicycleEditorService : IBicycleEditorService
    {
        public BicycleModel EditBicycle(BicycleModel? bicycle)
        {
            var createEditWindow = new CreateEditBicycleWindow(bicycle);
            
            if(createEditWindow.ShowDialog() == true)
            {
                return createEditWindow.Bicycle;
            }

            return null;
        }
    }
}
