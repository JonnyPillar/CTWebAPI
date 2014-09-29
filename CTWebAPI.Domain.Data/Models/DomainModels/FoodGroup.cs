using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CTWebAPI.Domain.Data.Models.APIContracts.FoodGroup;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class FoodGroup
    {
        public FoodGroup()
        {
            Foods = new HashSet<Food>();
        }

        public FoodGroup(FoodGroupPostModel foodGroupPostModel)
        {
            Name = foodGroupPostModel.Name;
            CreationTimestamp = DateTime.UtcNow;
            LastUpdatedTimestamp = DateTime.UtcNow;

            Foods = new HashSet<Food>();
        }
        public FoodGroup(FoodGroupPutModel foodGroupPutModel)
        {
            FoodGroupID = foodGroupPutModel.FoodGroupID;
            Name = foodGroupPutModel.Name;
            CreationTimestamp = foodGroupPutModel.CreationTimestamp;
            LastUpdatedTimestamp = DateTime.UtcNow;
        }

        [Key]
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