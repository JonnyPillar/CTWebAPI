using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class FoodGroup
    {
        public FoodGroup()
        {
            Foods = new HashSet<Food>();
        }

        [ScaffoldColumn(false)]
        [DataMember]
        public int FoodGroupID { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [DataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<Food> Foods { get; set; }
    }
}