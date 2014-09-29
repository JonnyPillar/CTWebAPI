using System;
using System.ComponentModel.DataAnnotations;

namespace CTWebAPI.Domain.Data.Models.APIContracts.FoodGroup
{
    public class FoodGroupPutModel
    {
        [Required]
        public int FoodGroupID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationTimestamp { get; set; }
    }
}