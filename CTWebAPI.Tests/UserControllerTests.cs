using System;
using System.Collections.Generic;
using System.Linq;
using CTWebAPI.Controllers;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CTWebAPI.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private IEnumerable<User> _fakeUsers;
        private Mock<IUserRepository> _userRepository;
        private UserController _userController;

        [TestInitialize]
        public void SetUp()
        {
            _fakeUsers = GetUsers();
            _userRepository = new Mock<IUserRepository>();
        }

        [TestMethod]
        public void UserController_Get_ReturnsSingleUser()
        {
            _userRepository.Setup(x => x.Get(1)).Returns(_fakeUsers.FirstOrDefault(x => x.UserID == 2));

            _userController = new UserController(_userRepository.Object);
            User user = _userController.Get(2);

            User expectedUser = _fakeUsers.FirstOrDefault(x => x.UserID == 2);
            Assert.AreSame(expectedUser, user);
        }

        [TestMethod]
        public void UserController_Get_ReturnsAllUsers()
        {
            _userRepository.Setup(x => x.GetRange(5)).Returns(_fakeUsers);

            var userController = new UserController(_userRepository.Object);
            IEnumerable<User> users = userController.GetRange(5);
            Assert.AreSame(_fakeUsers, users);
        }

        private IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = new List<User>
            {
                new User
                {
                    UserID = 0,
                    DOB = DateTime.Now,
                    Gender = false,
                    Admin = false,
                    CreationTimestamp = DateTime.Now
                },
                new User
                {
                    UserID = 1,
                    DOB = DateTime.Now,
                    Gender = false,
                    Admin = false,
                    CreationTimestamp = DateTime.Now
                },
                new User
                {
                    UserID = 2,
                    DOB = DateTime.Now,
                    Gender = false,
                    Admin = false,
                    CreationTimestamp = DateTime.Now
                },
                new User
                {
                    UserID = 3,
                    DOB = DateTime.Now,
                    Gender = false,
                    Admin = false,
                    CreationTimestamp = DateTime.Now
                },
                new User
                {
                    UserID = 4,
                    DOB = DateTime.Now,
                    Gender = false,
                    Admin = false,
                    CreationTimestamp = DateTime.Now
                }
            }.AsEnumerable();
            return users;
        }
    }
}