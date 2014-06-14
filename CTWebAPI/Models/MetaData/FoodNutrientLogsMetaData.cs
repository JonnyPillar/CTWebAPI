using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.MetaData
{
    public class FoodNutrientLogsMetaData
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int NurtientLogID { get; set; }

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

        [DataMember]
        public virtual Food tbl_foods { get; set; }

        [DataMember]
        public virtual Nutrient tbl_nutrients { get; set; }
    }
}