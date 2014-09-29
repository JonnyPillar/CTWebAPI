using System.ComponentModel.DataAnnotations;

namespace CTWebAPI.Domain.Data.Models.APIContracts.FoodGroup
{
    public class FoodGroupPostModel
    {
        [Required]
        public string Name { get; set; }
    }
}