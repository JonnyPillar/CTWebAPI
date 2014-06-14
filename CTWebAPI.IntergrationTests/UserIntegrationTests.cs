using System;
using CTWebAPI.Models;
using CTWebAPI.Repository.DataLayer;
using CTWebAPI.Repository.Interfaces;
using NUnit.Framework;

namespace CTWebAPI.IntergrationTests
{
    //[TestFixture]
    internal class UserIntegrationTests
    {
        //[SetUp]
        //public void Init()
        //{
        //    _unitOfWork = new EFUnitOfWork();
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    _unitOfWork.Dispose();
        //}

        //private IUnitOfWork _unitOfWork;

        //private User DoesUserExist(User user)
        //{
        //    User retreivedUser = _unitOfWork.UserRepository.Get(user.UserID);
        //    return retreivedUser;
        //}

        //private void RemoveUserFromDatabase(User user)
        //{
        //    _unitOfWork.UserRepository.Delete(user);
        //    _unitOfWork.SaveChanges();
        //}

        ////[Test]
        ////public void User_Create_Successfull_SingleUser()
        ////{
        ////    var newUser = new User
        ////    {
        ////        UserID = 10629,
        ////        DOB = DateTime.Now,
        ////        Gender = false,
        ////        PasswordHash = "50BAB767BB80B7922127CBA1A2976304C7F7338CD71C04BCFFB1F72846A67518",
        ////        PasswordSalt= "C8800D6EBC57D681972855CADCFF85FC2DB4AEF2F06864F6AF75F20E4A72B73F",
        ////        Admin = false,
        ////        CreationTimestamp = DateTime.Now,
        ////        ActivityLevelType = 0,
        ////        Personality = 0
        ////    };

        ////    _unitOfWork.UserRepository.Create(newUser);
        ////    _unitOfWork.SaveChanges();

        ////    User retrivedUser = DoesUserExist(newUser);
        ////    Assert.IsNotNull(retrivedUser);
        ////    Assert.AreEqual(newUser.UserID, retrivedUser.UserID);
        ////    Assert.AreEqual(newUser.Gender, retrivedUser.Gender);
        ////    Assert.AreEqual(newUser.Admin, retrivedUser.Admin);
        ////    Assert.AreEqual(newUser.CreationTimestamp, retrivedUser.CreationTimestamp);

        ////    RemoveUserFromDatabase(retrivedUser);
        ////}
    }
}