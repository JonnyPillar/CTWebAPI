using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CTWebAPI.Models.DomainModels;

namespace CTWebAPI.Models.MetaData
{
    public class NutrientMetaData
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int NutrientID { get; set; }

        [DataMember]
        [Display(Name = "Source ID")]
        public int SourceID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Unit Type")]
        public int UnitType { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Decimal Rounding")]
        public int DecimalRounding { get; set; }

        [ScaffoldColumn(false)]
        [IgnoreDataMember]
        public virtual ICollection<FoodNutrientRecord> tbl_food_nutrition_logs { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual ICollection<NutrientRDAMetaData> tbl_nutrient_rda { get; set; }
    }
}