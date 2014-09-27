using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.DomainModels
{
    public class NutrientRDA
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int NutrientRDAID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Nutrient IDs")]
        public int NutrientID { get; set; }

        [Required]
        [DataMember]
        public bool Gender { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Age Min")]
        public int AgeMin { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Age Max")]
        public int AgeMax { get; set; }

        [Required]
        [DataMember]
        public decimal Value { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Unit Type")]
        public int UnitType { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }
        
        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [DataMember]
        public virtual Nutrient Nutrient { get; set; }
    }
}