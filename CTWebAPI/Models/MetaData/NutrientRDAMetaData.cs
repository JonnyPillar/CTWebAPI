using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CTWebAPI.Models.MetaData
{
    public class NutrientRDAMetaData
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

        [DataMember]
        public virtual Nutrient tbl_nutrients { get; set; }
    }
}