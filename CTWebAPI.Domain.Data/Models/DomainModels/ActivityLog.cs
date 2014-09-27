using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class ActivityLog
    {
        [ScaffoldColumn(false)]
        [DataMember]
        public int ActivityLogID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Activity ID")]
        public int ActivityID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataMember]
        public TimeSpan Duration { get; set; }

        [Required]
        [DataMember]
        public decimal Distance { get; set; }

        [Required]
        [DataMember]
        public string Title { get; set; }

        [Required]
        [DataMember]
        public decimal Accent { get; set; }

        [DataMember]
        [Display(Name = "Heart Rate")]
        public int HeartRate { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        [Display(Name = "File URL")]
        public string FileURL { get; set; }

        [Required]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual Activity Activity { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual User User { get; set; }
    }
}