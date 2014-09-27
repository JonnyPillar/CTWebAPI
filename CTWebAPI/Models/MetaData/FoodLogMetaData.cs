﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CTWebAPI.Models.DomainModels;

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
        public DateTime CreationTimestamp { get; set; }

        [DataMember]
        public virtual Food tbl_foods { get; set; }

        [DataMember]
        public virtual User tbl_users { get; set; }
    }
}