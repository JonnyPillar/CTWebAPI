using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class Activity
    {
        public Activity()
        {
            ActivityLogs = new HashSet<ActivityLog>();
        }

        [ScaffoldColumn(false)]
        [DataMember]
        public int ActivityID { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Calorie Burn Rate")]
        [DataMember]
        public decimal CalorieBurnRate { get; set; }

        [Required]
        [Display(Name = "Image Burn Rate")]
        [DataMember]
        public string ImageUrl { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}