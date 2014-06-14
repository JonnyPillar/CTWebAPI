using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.MetaData
{
    public class FoodMetaData
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int FoodID { get; set; }

        [Display(Name = "Source ID")]
        [DataMember]
        public int SourceID { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        //TODO Remove
        public int? ParentID { get; set; }

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

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual FoodGroup tbl_food_groups { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodLog> tbl_food_logs { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodNutrientLogs> tbl_food_nutrition_logs { get; set; }
    }
}