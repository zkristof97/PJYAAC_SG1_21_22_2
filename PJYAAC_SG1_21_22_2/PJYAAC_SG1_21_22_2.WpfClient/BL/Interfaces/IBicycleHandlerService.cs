using PJYAAC_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.WpfClient.BL.Interfaces
{
    public interface IBicycleHandlerService
    {
        void AddBicycle(IList<BicycleModel> collection);
        void EditBicycle(BicycleModel bicycle);
        void DeleteBicycle(IList<BicycleModel> collection, BicycleModel bicycle);

        IEnumerable<BicycleModel> GetAll();
    }
}
