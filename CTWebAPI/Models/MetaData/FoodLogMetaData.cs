using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CTWebAPI.Models.MetaData
{
    public class FoodLogMetaData
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int FoodLogID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Food ID")]
        public int FoodID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Required]
        [DataMember]
        public decimal Quantity { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Created")]
        public System.DateTime CreationTimestamp { get; set; }

        [DataMember]
        public virtual Food tbl_foods { get; set; }

        [DataMember]
        public virtual User tbl_users { get; set; }
    }
}