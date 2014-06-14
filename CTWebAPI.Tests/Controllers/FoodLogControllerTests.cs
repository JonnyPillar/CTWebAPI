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

namespace CTWebAPI.Tests.Controllers
{
    internal class FoodLogControllerTests
    {
        private IEnumerable<FoodLog> _fakeFoodLog;
        private FoodLogController _foodLogController;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            _fakeFoodLog = GetActivites();
        }

        private IEnumerable<FoodLog> GetActivites()
        {
            IEnumerable<FoodLog> activities = new List<FoodLog>
            {
                new FoodLog
                {
                    FoodLogID = 0,
                    FoodID = 101,
                    UserID = 8,
                    Quantity = 10,
                    CreationTimestamp = DateTime.Now
                },
                new FoodLog
                {
                    FoodLogID = 1,
                    FoodID = 101,
                    UserID = 8,
                    Quantity = 10,
                    CreationTimestamp = DateTime.Now
                },
                new FoodLog
                {
                    FoodLogID = 2,
                    FoodID = 101,
                    UserID = 8,
                    Quantity = 10,
                    CreationTimestamp = DateTime.Now
                },
                new FoodLog
                {
                    FoodLogID = 3,
                    FoodID = 101,
                    UserID = 8,
                    Quantity = 10,
                    CreationTimestamp = DateTime.Now
                },
                new FoodLog
                {
                    FoodLogID = 4,
                    FoodID = 101,
                    UserID = 8,
                    Quantity = 10,
                    CreationTimestamp = DateTime.Now
                },
            }.AsEnumerable();
            return activities;
        }

        [Test]
        public void FoodLogController_Get_ReturnsAllFoodLogs()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodLogRepository.Get()).Returns(_fakeFoodLog);
            var foodLogController = new FoodLogController(_unitOfWork.Object);

            IEnumerable<FoodLog> activities = foodLogController.Get();
            Assert.AreSame(_fakeFoodLog, activities);
        }

        [Test]
        public void FoodLogController_Get_ReturnsCorrectFoodLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedFoodLog = new FoodLog
            {
                FoodLogID = 0,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };
            _unitOfWork.Setup(x => x.FoodLogRepository.GetAsync(2)).ReturnsAsync(expectedFoodLog);
            _foodLogController = new FoodLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodLogController.Get(2).Result;
            var returnedFoodLog = actionResult as OkNegotiatedContentResult<FoodLog>;

            Assert.IsNotNull(returnedFoodLog);
            Assert.AreSame(expectedFoodLog, returnedFoodLog.Content);
        }

        [Test]
        public void FoodLogController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodLogRepository.Get(2));
            _foodLogController = new FoodLogController(_unitOfWork.Object);

            IHttpActionResult response = _foodLogController.Get(2).Result;
            var returnedFoodLog = response as OkNegotiatedContentResult<FoodLog>;

            Assert.IsNull(returnedFoodLog); //If null somethings gone wrong
        }

        [Test]
        public void FoodLogController_Post_SuccessfulInsert()
        {
            var createdFoodLog = new FoodLog
            {
                FoodLogID = 1,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodLogRepository.Create(createdFoodLog));

            var foodLogController = new FoodLogController(_unitOfWork.Object);
            IHttpActionResult response = foodLogController.Post(createdFoodLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodLog>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FoodLog>(result.Content);
            Assert.AreEqual(createdFoodLog, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodLogController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodLogRepository.Create(null));

            var foodLogController = new FoodLogController(_unitOfWork.Object);
            IHttpActionResult response = foodLogController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<FoodLog>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodLogController_Put_SuccessfulUpdate()
        {
            var currentFoodLog = new FoodLog
            {
                FoodLogID = 2,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };

            var updatedFoodLog = new FoodLog
            {
                FoodLogID = 2,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodLogRepository.Get(2)).Returns(currentFoodLog);
            _unitOfWork.Setup(i => i.FoodLogRepository.Update(updatedFoodLog));

            var foodLogController = new FoodLogController(_unitOfWork.Object);
            IHttpActionResult response = foodLogController.Put(updatedFoodLog.FoodLogID, updatedFoodLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodLog>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FoodLog>(result.Content);
            Assert.AreEqual(updatedFoodLog, result.Content);
            Assert.AreEqual(updatedFoodLog.Quantity, result.Content.Quantity);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodLogController_Put_UnsuccessfulInsert_DifferentFoodLog()
        {
            var currentFoodLog = new FoodLog
            {
                FoodLogID = 3,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };

            var updatedFoodLog = new FoodLog
            {
                FoodLogID = 2,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodLogRepository.Get(2)).Returns(currentFoodLog);
            _unitOfWork.Setup(i => i.FoodLogRepository.Update(updatedFoodLog));

            var foodLogController = new FoodLogController(_unitOfWork.Object);
            IHttpActionResult response = foodLogController.Put(updatedFoodLog.FoodLogID, updatedFoodLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodLog>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodLogController_Put_UnsuccessfulInsert_NoFoodLog()
        {
            var updatedFoodLog = new FoodLog
            {
                FoodLogID = 2,
                FoodID = 101,
                UserID = 8,
                Quantity = 10,
                CreationTimestamp = DateTime.Now
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodLogRepository.Get(2));
            _unitOfWork.Setup(i => i.FoodLogRepository.Update(updatedFoodLog));

            var foodLogController = new FoodLogController(_unitOfWork.Object);
            IHttpActionResult response = foodLogController.Put(updatedFoodLog.FoodLogID, updatedFoodLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodLog>;

            Assert.IsNull(result);
        }
    }
}