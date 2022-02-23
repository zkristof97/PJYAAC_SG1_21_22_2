using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJYAAC_SG1_21_22_2.Models.Entities
{
    public class Bicycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateOfPurchase { get; set; }

        [Required]
        public int Price { get; set; }
        public bool IsFullSuspension { get; set; }
        public bool IsElectric { get; set; }
        public string Color { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
    }
}
