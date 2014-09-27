using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.DomainModels
{
    public class Food
    {
        public Food()
        {
            FoodLogs = new HashSet<FoodLog>();
            FoodNutrientLogs = new HashSet<FoodNutrientRecord>();
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
        public virtual FoodGroup FoodGroup { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodLog> FoodLogs { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodNutrientRecord> FoodNutrientLogs { get; set; }
    }
}