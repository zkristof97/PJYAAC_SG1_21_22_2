using GalaSoft.MvvmLight.Messaging;
using PJYAAC_SG1_21_22_2.WpfClient.BL.Interfaces;
using PJYAAC_SG1_21_22_2.WpfClient.Infrastructure;
using PJYAAC_SG1_21_22_2.WpfClient.Infrastructure.Interfaces;
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
        private readonly IBicycleDisplayService _bicycleDisplayService;
        private readonly IMessenger _messenger;
        private readonly IHttpService _httpService;

        public BicycleHandlerService(IBicycleEditorService bicycleEditorService
            , IMessenger messenger
            , IBicycleDisplayService bicycleDisplayService
            , IHttpService httpService)
        {
            _bicycleEditorService = bicycleEditorService;
            _bicycleDisplayService = bicycleDisplayService;
            _httpService = httpService;
            _messenger = messenger;
        }

        public void AddBicycle(IList<BicycleModel> collection)
        {
            bool isOperationFinished = false;
            BicycleModel bicycleToCreate = null;

            do
            {
                var createdBike = _bicycleEditorService.EditBicycle(bicycleToCreate);

                if (createdBike != null)
                {
                    var createResult = _httpService.Create(createdBike);

                    bicycleToCreate = createdBike;
                    if (createResult.IsSuccess)
                    {
                        isOperationFinished = true;
                        RefreshCollectionFromServer(collection);
                        SendMessage("Létrehozás sikeresen megtörtént.");
                    } else
                    {
                        SendMessage(createResult.ExceptionMessages.ToArray());
                    }
                } else
                {
                    isOperationFinished = true;
                    SendMessage("Létrehozás megszakítva.");
                }
            } while (!isOperationFinished);
        }

        public void DeleteBicycle(IList<BicycleModel> collection, BicycleModel bicycle)
        {
            if(bicycle != null)
            {
                var deleteResult = _httpService.Delete(bicycle.Id);

                if(deleteResult.IsSuccess)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Törölve!");
                } else
                {
                    SendMessage(deleteResult.ExceptionMessages.ToArray());
                }
            }
        }

        public void EditBicycle(IList<BicycleModel> collection, BicycleModel bicycle)
        {
            bool isOperationFinished = false;
            BicycleModel bicycleToEdit = bicycle;

            do
            {
                var editedBike = _bicycleEditorService.EditBicycle(bicycleToEdit);
            
                if (editedBike != null)
                {
                    var updateResult = _httpService.Update(editedBike);

                    bicycleToEdit = editedBike;
                    if (updateResult.IsSuccess)
                    {
                        isOperationFinished = true;
                        RefreshCollectionFromServer(collection);
                        SendMessage("Változtatások mentve.");
                    } else
                    {
                        SendMessage(updateResult.ExceptionMessages.ToArray());
                    }
                } else
                {
                    isOperationFinished = true;
                    SendMessage("Szerkesztés megszakítva.");
                }
            } while (!isOperationFinished);
        }

        public IEnumerable<BicycleModel> GetAll()
        {
            return _httpService.GetAll<BicycleModel>();
        }

        public void ViewDetails(BicycleModel bicycle)
        {
            _bicycleDisplayService.Display(bicycle);
        }

        private void SendMessage(params string[] messages)
        {
            _messenger.Send(messages, "OperationResult");
        }

        private void RefreshCollectionFromServer(IList<BicycleModel> collection)
        {
            collection.Clear();
            var newBicycles = GetAll();

            foreach (var bicycle in newBicycles)
            {
                collection.Add(bicycle);
            }
        }
    }
}
