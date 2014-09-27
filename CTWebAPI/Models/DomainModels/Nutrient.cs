using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.DomainModels
{
    public class Nutrient
    {
        public Nutrient()
        {
            FoodNutrientRecords = new HashSet<FoodNutrientRecord>();
            NutrientRDAs = new HashSet<NutrientRDA>();
        }

        [ScaffoldColumn(false)]
        [DataMember]
        public int NutrientID { get; set; }

        [DataMember]
        [Display(Name = "Source ID")]
        public int UnitType { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Decimal Rounding")]
        public int DecimalRounding { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [ScaffoldColumn(false)]
        [IgnoreDataMember]
        public virtual ICollection<FoodNutrientRecord> FoodNutrientRecords { get; set; }

        [ScaffoldColumn(false)]
        [IgnoreDataMember]
        public virtual ICollection<NutrientRDA> NutrientRDAs { get; set; }
    }
}