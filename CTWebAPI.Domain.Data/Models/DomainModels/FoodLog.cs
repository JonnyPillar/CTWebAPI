using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class FoodLog
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
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [DataMember]
        public virtual Food Food { get; set; }

        [DataMember]
        public virtual User User { get; set; }
    }
}