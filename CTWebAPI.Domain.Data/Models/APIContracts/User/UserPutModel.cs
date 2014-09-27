using System;

namespace CTWebAPI.Domain.Data.Models.APIContracts.User
{
    public class UserPutModel
    {
        public int UserID;
        public DateTime DOB;
        public string EmailAddress;
        public string FirstName;
        public int Gender;
        public string LastName;
        public string Password;
    }
}