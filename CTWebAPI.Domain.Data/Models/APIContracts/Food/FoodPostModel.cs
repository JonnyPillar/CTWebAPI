using System.ComponentModel.DataAnnotations;

namespace CTWebAPI.Domain.Data.Models.APIContracts.Food
{
    public class FoodPostModel
    {
        [Required]
        public int GroupID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ManufactureName { get; set; }
    }
}