using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CTWebAPI.Models.MetaData
{
    public class ActivityMetaData
    {
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

        [IgnoreDataMember]
        [ScaffoldColumn(false)]
        public virtual ICollection<ActivityLogs> tbl_activity_logs { get; set; }
    }
}