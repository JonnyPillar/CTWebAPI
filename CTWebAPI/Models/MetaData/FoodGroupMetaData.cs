using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CTWebAPI.Models.DomainModels;

namespace CTWebAPI.Models.MetaData
{
    public class FoodGroupMetaData
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int FoodGroupID { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Source ID")]
        public int SourceID { get; set; }

        [DataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<Food> tbl_foods { get; set; }
    }
}