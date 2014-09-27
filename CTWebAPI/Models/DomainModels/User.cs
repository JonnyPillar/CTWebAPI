using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CTWebAPI.Models.DomainModels
{
    public class User
    {
        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            FoodLogs = new HashSet<FoodLog>();
        }

        [ScaffoldColumn(false)]
        [DataMember]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataMember]
        public string EmailAddress { get; set; }

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

        [Required]
        [ScaffoldColumn(false)]
        [DataMember]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        [DataMember]
        public DateTime LastUpdatedTimestamp { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual ICollection<FoodLog> FoodLogs { get; set; }
    }
}