using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.Models.DTOs
{
    public class BicycleDTO
    {
        public int Id { get; set; }

        public DateTime DateOfPurchase { get; set; }
        public int Price { get; set; }
        public bool IsFullSuspension { get; set; }
        public bool IsElectric { get; set; }
        public string Color { get; set; }

        public string Type { get; set; }

        public string Model { get; set; }
    }
}
