using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.WpfClient.Models
{
    public class BicycleModel : ObservableObject, ICloneable
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }


        private DateTime dateOfPurchase;

        public DateTime DateOfPurchase
        {
            get { return dateOfPurchase; }
            set { Set(ref dateOfPurchase, value); }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { Set(ref price, value); }
        }

        private bool isFullSuspension;

        public bool IsFullSuspension
        {
            get { return isFullSuspension; }
            set { Set(ref isFullSuspension, value); }
        }

        private bool isElectric;

        public bool IsElectric
        {
            get { return isElectric; }
            set { Set(ref isElectric, value); }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { Set(ref color, value); }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { Set(ref model, value); }
        }

        public BicycleModel()
        {

        }

        public BicycleModel(int id, DateTime dateOfPurchase, int price, bool isFullSuspension, bool isElectric, string color, string type, string model)
        {
            this.id = id;
            this.dateOfPurchase = dateOfPurchase;
            this.price = price;
            this.isFullSuspension = isFullSuspension;
            this.isElectric = isElectric;
            this.color = color;
            this.type = type;
            this.model = model;
        }

        public object Clone()
        {
            return new BicycleModel(
                Id,
                DateOfPurchase,
                Price,
                IsFullSuspension,
                IsElectric,
                Color,
                Type,
                Model
            );
        }
    }
}
