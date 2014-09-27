using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class FoodNutrientRecord
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int FoodNutrientRecordID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Food ID")]
        public int FoodID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Nutrient ID")]
        public int NurtientID { get; set; }

        [Required]
        [DataMember]
        public decimal Value { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [DataMember]
        public virtual Food Food { get; set; }

        [DataMember]
        public virtual Nutrient Nutrient { get; set; }
    }
}