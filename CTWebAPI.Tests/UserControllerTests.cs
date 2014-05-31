using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
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
        private UserController _userController;
        private Mock<IUserRepository> _userRepository;

        [TestInitialize]
        public void SetUp()
        {
            _fakeUsers = GetUsers();
        }

        [TestMethod]
        public void UserController_Get_ReturnsAllUsers()
        {
            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.Get()).Returns(_fakeUsers);
            var userController = new UserController(_userRepository.Object);

            IEnumerable<User> users = userController.Get();
            Assert.AreSame(_fakeUsers, users);
        }

        [TestMethod]
        public void UserController_Get_ReturnsSingleUser()
        {
            _userRepository = new Mock<IUserRepository>();
            var expectedUser = new User
            {
                UserID = 2,
                DOB = DateTime.Now,
                Gender = false,
                Admin = false,
                CreationTimestamp = DateTime.Now
            };

            _userRepository.Setup(x => x.Get(2)).Returns(expectedUser);
            _userController = new UserController(_userRepository.Object);

            IHttpActionResult actionResult = _userController.Get(2);
            var user = actionResult as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(user);
            Assert.AreSame(expectedUser, user.Content);
        }

        [TestMethod]
        public void UserController_Get_ReturnsNotFound()
        {
            _userRepository = new Mock<IUserRepository>();
            _userController = new UserController(_userRepository.Object);
            IHttpActionResult actionResult = _userController.Get(2);
            Assert.IsInstanceOfType(actionResult, typeof (NotFoundResult));
        }

        [TestMethod]
        public void UserController_GetRange_ReturnsUsersInRange()
        {
            _userRepository = new Mock<IUserRepository>();
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