using PJYAAC_SG1_21_22_2.WpfClient.BL.Interfaces;
using PJYAAC_SG1_21_22_2.WpfClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.WpfClient.BL.Implementation
{
    public class BicycleHandlerService : IBicycleHandlerService
    {
        private readonly IBicycleEditorService _bicycleEditorService;

        public BicycleHandlerService(IBicycleEditorService bicycleEditorService)
        {
            _bicycleEditorService = bicycleEditorService;
        }

        public void AddBicycle(IList<BicycleModel> collection)
        {
            var createdBike = _bicycleEditorService.EditBicycle(null);

            if(createdBike != null)
            {
                collection.Add(createdBike);
            }
        }

        public void DeleteBicycle(IList<BicycleModel> collection, BicycleModel bicycle)
        {
            if(bicycle != null)
            {
                collection.Remove(bicycle);
            }
        }

        public void EditBicycle(BicycleModel bicycle)
        {
            var editedBike = _bicycleEditorService.EditBicycle(bicycle);

            if(editedBike != null)
            {
                bicycle.DateOfPurchase = editedBike.DateOfPurchase;
                bicycle.Price = editedBike.Price;
                bicycle.IsFullSuspension = editedBike.IsFullSuspension;
                bicycle.IsElectric = editedBike.IsElectric;
                bicycle.Color = editedBike.Color;
                bicycle.Type = editedBike.Type;
                bicycle.Model = editedBike.Model;
            }
        }
    }
}
