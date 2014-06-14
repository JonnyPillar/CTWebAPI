using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.MetaData
{
    public class UserMetaData
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataMember]
        public DateTime DOB { get; set; }

        [Required]
        [DataMember]
        public bool Gender { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public string PasswordHash { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public string PasswordSalt { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public bool Admin { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public int ActivityLevelType { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public int Personality { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<ActivityLog> tbl_activity_logs { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<FoodLog> tbl_food_logs { get; set; }

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<MetricLogs> tbl_metric_logs { get; set; }
    }
}