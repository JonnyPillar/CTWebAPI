using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using CTWebAPI.Domain.Data.Models.APIContracts.User;

namespace CTWebAPI.Domain.Data.Models.DomainModels
{
    public class User
    {
        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            FoodLogs = new HashSet<FoodLog>();
        }

        public User(UserPostModel userModel)
        {
            FirstName = userModel.FirstName;
            LastName = userModel.LastName;
            EmailAddress = userModel.EmailAddress;
            DOB = userModel.DOB;
            Gender = Convert.ToBoolean(userModel.Gender);
            //TODO Password
            CreationTimestamp = DateTime.UtcNow;
            LastUpdatedTimestamp = DateTime.UtcNow;

            ActivityLogs = new HashSet<ActivityLog>();
            FoodLogs = new HashSet<FoodLog>();
        }

        public User(UserPutModel userModel)
        {
            UserID = userModel.UserID;
            FirstName = userModel.FirstName;
            LastName = userModel.LastName;
            EmailAddress = userModel.EmailAddress;
            DOB = userModel.DOB;
            Gender = Convert.ToBoolean(userModel.Gender);
            //TODO Password
            CreationTimestamp = DateTime.UtcNow;
            LastUpdatedTimestamp = DateTime.UtcNow;

            ActivityLogs = new HashSet<ActivityLog>();
            FoodLogs = new HashSet<FoodLog>();
        }

        [Key]
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

        [ScaffoldColumn(false)]
        [DataMember]
        [Required]
        public DateTime CreationTimestamp { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        [Required]
        public DateTime LastUpdatedTimestamp { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

        [ScaffoldColumn(false)]
        [DataMember]
        public virtual ICollection<FoodLog> FoodLogs { get; set; }
    }
}