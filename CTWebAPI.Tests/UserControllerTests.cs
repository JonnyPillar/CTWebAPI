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
        private Mock<IUnitOfWork> _unitOfWork;

        [TestInitialize]
        public void SetUp()
        {
            _fakeUsers = GetUsers();
        }

        [TestMethod]
        public void UserController_Get_ReturnsAllUsers()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.UserRepository.Get()).Returns(_fakeUsers);
            var userController = new UserController(_unitOfWork.Object);

            IEnumerable<User> users = userController.Get();
            Assert.AreSame(_fakeUsers, users);
        }

        [TestMethod]
        public void UserController_Get_ReturnsSingleUser()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedUser = new User
            {
                UserID = 2,
                DOB = DateTime.Now,
                Gender = false,
                Admin = false,
                CreationTimestamp = DateTime.Now
            };

            _unitOfWork.Setup(x => x.UserRepository.Get(2)).Returns(expectedUser);
            _userController = new UserController(_unitOfWork.Object);

            IHttpActionResult actionResult = _userController.Get(2);
            var user = actionResult as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(user);
            Assert.AreSame(expectedUser, user.Content);
        }

        

        [TestMethod]
        public void UserController_GetRange_ReturnsUsersInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.UserRepository.GetRange(5)).Returns(_fakeUsers);
            var userController = new UserController(_unitOfWork.Object);

            IEnumerable<User> users = userController.GetRange(5);
            Assert.AreSame(_fakeUsers, users);
        }

        [TestMethod]
        public void UserController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.UserRepository.Get(2));
            _userController = new UserController(_unitOfWork.Object);
            IHttpActionResult actionResult = _userController.Get(2);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
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