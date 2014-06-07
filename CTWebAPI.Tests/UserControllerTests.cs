using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using CTWebAPI.Controllers;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace CTWebAPI.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeUsers = GetUsers();
        }

        private IEnumerable<User> _fakeUsers;
        private UserController _userController;
        private Mock<IUnitOfWork> _unitOfWork;

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

        [Test]
        public void UserController_Delete_DeletesUser()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var userToDelete = new User
            {
                UserID = 2,
                DOB = DateTime.Now,
                Gender = false,
                Admin = false,
                CreationTimestamp = DateTime.Now
            };

            _unitOfWork.Setup(x => x.UserRepository.Delete(userToDelete));
            _userController = new UserController(_unitOfWork.Object);

            IHttpActionResult actionResult = _userController.Delete(userToDelete).Result;
            var user = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(user);
        }

        [Test]
        public void UserController_Delete_NullUser()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.UserRepository.Delete(null));
            _userController = new UserController(_unitOfWork.Object);

            IHttpActionResult actionResult = _userController.Delete(null).Result;
            var user = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(user);
        }

        [Test]
        public void UserController_GetRange_ReturnsUsersInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.UserRepository.GetRange(5)).Returns(_fakeUsers);
            var userController = new UserController(_unitOfWork.Object);

            IEnumerable<User> users = userController.GetRange(5);
            Assert.AreEqual(_fakeUsers.Count(), users.Count());
        }

        [Test]
        public void UserController_Get_ReturnsAllUsers()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.UserRepository.Get()).Returns(_fakeUsers);
            var userController = new UserController(_unitOfWork.Object);

            IEnumerable<User> users = userController.Get();
            Assert.AreSame(_fakeUsers, users);
        }

        [Test]
        public void UserController_Get_ReturnsCorrectUser()
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
            _unitOfWork.Setup(x => x.UserRepository.GetAsync(2)).ReturnsAsync(expectedUser);
            _userController = new UserController(_unitOfWork.Object);

            IHttpActionResult actionResult = _userController.Get(2).Result;
            var user = actionResult as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(user);
            Assert.AreSame(expectedUser, user.Content);
        }

        [Test]
        public void UserController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.UserRepository.Get(2));
            _userController = new UserController(_unitOfWork.Object);

            IHttpActionResult response = _userController.Get(2).Result;
            var user = response as OkNegotiatedContentResult<User>;

            Assert.IsNull(user); //If null somethings gone wrong
        }

        [Test]
        public void UserController_Post_SuccessfulInsert()
        {
            var createdUser = new User();
            createdUser.UserID = 1;
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.UserRepository.Create(createdUser));

            var userController = new UserController(_unitOfWork.Object);
            IHttpActionResult response = userController.Post(createdUser).Result;
            var result = response as CreatedNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<User>(result.Content);
            Assert.AreEqual(createdUser, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void UserController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.UserRepository.Create(null));

            var userController = new UserController(_unitOfWork.Object);
            IHttpActionResult response = userController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<User>;

            Assert.IsNull(result);
        }

        [Test]
        public void UserController_Put_SuccessfulUpdate()
        {
            var currentUser = new User();
            currentUser.UserID = 2;
            currentUser.DOB = new DateTime(1991, 02, 21);

            var updatedUser = new User();
            updatedUser.UserID = 2;
            updatedUser.DOB = new DateTime(1992, 03, 22);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.UserRepository.Get(2)).Returns(currentUser);
            _unitOfWork.Setup(i => i.UserRepository.Update(updatedUser));

            var userController = new UserController(_unitOfWork.Object);
            IHttpActionResult response = userController.Put(updatedUser.UserID, updatedUser).Result;
            var result = response as CreatedNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<User>(result.Content);
            Assert.AreEqual(updatedUser, result.Content);
            Assert.AreEqual(updatedUser.DOB, result.Content.DOB);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void UserController_Put_UnsuccessfulInsert_DifferentUser()
        {
            var currentUser = new User();
            currentUser.UserID = 3;
            currentUser.DOB = new DateTime(1991, 02, 21);

            var updatedUser = new User();
            updatedUser.UserID = 2;
            updatedUser.DOB = new DateTime(1992, 03, 22);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.UserRepository.Get(2)).Returns(currentUser);
            _unitOfWork.Setup(i => i.UserRepository.Update(updatedUser));

            var userController = new UserController(_unitOfWork.Object);
            IHttpActionResult response = userController.Put(updatedUser.UserID, updatedUser).Result;
            var result = response as CreatedNegotiatedContentResult<User>;

            Assert.IsNull(result);
        }

        [Test]
        public void UserController_Put_UnsuccessfulInsert_NoUser()
        {
            var currentUser = new User();
            currentUser.UserID = 2;
            currentUser.DOB = new DateTime(1991, 02, 21);

            var updatedUser = new User();
            updatedUser.UserID = 2;
            updatedUser.DOB = new DateTime(1992, 03, 22);

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.UserRepository.Get(2));
            _unitOfWork.Setup(i => i.UserRepository.Update(updatedUser));

            var userController = new UserController(_unitOfWork.Object);
            IHttpActionResult response = userController.Put(updatedUser.UserID, updatedUser).Result;
            var result = response as CreatedNegotiatedContentResult<User>;

            Assert.IsNull(result);
        }
    }
}