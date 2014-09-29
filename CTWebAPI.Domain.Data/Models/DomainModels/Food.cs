using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CTWebAPI.Domain.Data.Models.APIContracts.Food;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class Food
    {
        public Food()
        {
            FoodLogs = new HashSet<FoodLog>();
            FoodNutrientLogs = new HashSet<FoodNutrientRecord>();
        }

        public Food(FoodPostModel foodPostModel)
        {
            GroupID = foodPostModel.GroupID;
            Name = foodPostModel.Name;
            Description = foodPostModel.Description;
            ManufactureName = string.IsNullOrWhiteSpace(foodPostModel.ManufactureName) ? string.Empty : foodPostModel.ManufactureName;
            CreationTimestamp = DateTime.UtcNow;
            LastUpdatedTimestamp = DateTime.UtcNow;

            FoodLogs = new HashSet<FoodLog>();
            FoodNutrientLogs = new HashSet<FoodNutrientRecord>();
        }
        public Food(FoodPutModel foodPutModel)
        {
            FoodID = foodPutModel.FoodID;
            GroupID = foodPutModel.GroupID;
            Name = foodPutModel.Name;
            Description = foodPutModel.Description;
            ManufactureName = string.IsNullOrWhiteSpace(foodPutModel.ManufactureName) ? string.Empty : foodPutModel.ManufactureName;
            CreationTimestamp = foodPutModel.CreationTimestamp;
            LastUpdatedTimestamp = DateTime.UtcNow;
        }

        [ScaffoldColumn(false)]
        [DataMember]
        public int FoodID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Food Group ID")]
        
        public int GroupID { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Manufacture Name")]
        [DataMember]
        public string ManufactureName { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        [ForeignKey("GroupID")]
        public virtual FoodGroup FoodGroup { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodLog> FoodLogs { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodNutrientRecord> FoodNutrientLogs { get; set; }
    }
}