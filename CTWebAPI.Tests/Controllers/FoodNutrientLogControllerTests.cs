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
    [TestFixture]
    internal class FoodNutrientLogControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeFoodNutrientLog = GetFoodNutrientLog();
        }

        private FoodNutrientLogController _foodNutrientLogController;
        private IEnumerable<FoodNutrientLog> _fakeFoodNutrientLog;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<FoodNutrientLog> GetFoodNutrientLog()
        {
            IEnumerable<FoodNutrientLog> foodNutrientLogs = new List<FoodNutrientLog>
            {
                new FoodNutrientLog
                {
                    NurtientLogID = 0,
                    FoodID = 101,
                    NurtientID = 2,
                    Value = 10
                },
                new FoodNutrientLog
                {
                    NurtientLogID = 1,
                    FoodID = 101,
                    NurtientID = 2,
                    Value = 10
                },
                new FoodNutrientLog
                {
                    NurtientLogID = 2,
                    FoodID = 101,
                    NurtientID = 2,
                    Value = 10
                },
                new FoodNutrientLog
                {
                    NurtientLogID = 3,
                    FoodID = 101,
                    NurtientID = 2,
                    Value = 10
                },
                new FoodNutrientLog
                {
                    NurtientLogID = 4,
                    FoodID = 101,
                    NurtientID = 2,
                    Value = 10
                }
            }.AsEnumerable();
            return foodNutrientLogs;
        }

        [Test]
        public void FoodNutrientLogController_Delete_DeletesFoodNutrientLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var foodNutrientLogToDelete = new FoodNutrientLog
            {
                NurtientLogID = 0,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };

            _unitOfWork.Setup(x => x.FoodNutrientLogRepository.Delete(foodNutrientLogToDelete));
            _foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodNutrientLogController.Delete(foodNutrientLogToDelete).Result;
            var foodNutrientLog = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(foodNutrientLog);
        }

        [Test]
        public void FoodNutrientLogController_Delete_NullFoodNutrientLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.FoodNutrientLogRepository.Delete(null));
            _foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodNutrientLogController.Delete(null).Result;
            var foodNutrientLog = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(foodNutrientLog);
        }

        [Test]
        public void FoodNutrientLogController_GetRange_ReturnsFoodNutrientLogsInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodNutrientLogRepository.GetRange(5)).Returns(_fakeFoodNutrientLog);
            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);

            IEnumerable<FoodNutrientLog> foodNutrientLogs = foodNutrientLogController.GetRange(5);
            Assert.AreEqual(_fakeFoodNutrientLog.Count(), foodNutrientLogs.Count());
        }

        [Test]
        public void FoodNutrientLogController_Get_ReturnsAllFoodNutrientLogs()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodNutrientLogRepository.Get()).Returns(_fakeFoodNutrientLog);
            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);

            IEnumerable<FoodNutrientLog> foodNutrientLogs = foodNutrientLogController.Get();
            Assert.AreSame(_fakeFoodNutrientLog, foodNutrientLogs);
        }

        [Test]
        public void FoodNutrientLogController_Get_ReturnsCorrectFoodNutrientLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 0,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };
            _unitOfWork.Setup(x => x.FoodNutrientLogRepository.GetAsync(2)).ReturnsAsync(expectedFoodNutrientLog);
            _foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodNutrientLogController.Get(2).Result;
            var returnedFoodNutrientLog = actionResult as OkNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNotNull(returnedFoodNutrientLog);
            Assert.AreSame(expectedFoodNutrientLog, returnedFoodNutrientLog.Content);
        }

        [Test]
        public void FoodNutrientLogController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodNutrientLogRepository.Get(2));
            _foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);

            IHttpActionResult response = _foodNutrientLogController.Get(2).Result;
            var returnedFoodNutrientLog = response as OkNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNull(returnedFoodNutrientLog); //If null somethings gone wrong
        }

        [Test]
        public void FoodNutrientLogController_Post_SuccessfulInsert()
        {
            var createdFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 1
            };
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Create(createdFoodNutrientLog));

            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);
            IHttpActionResult response = foodNutrientLogController.Post(createdFoodNutrientLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FoodNutrientLog>(result.Content);
            Assert.AreEqual(createdFoodNutrientLog, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodNutrientLogController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Create(null));

            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);
            IHttpActionResult response = foodNutrientLogController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodNutrientLogController_Put_SuccessfulUpdate()
        {
            var currentFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 2,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };

            var updatedFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 2,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Get(2)).Returns(currentFoodNutrientLog);
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Update(updatedFoodNutrientLog));

            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);
            IHttpActionResult response =
                foodNutrientLogController.Put(updatedFoodNutrientLog.NurtientLogID, updatedFoodNutrientLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FoodNutrientLog>(result.Content);
            Assert.AreEqual(updatedFoodNutrientLog, result.Content);
            Assert.AreEqual(updatedFoodNutrientLog.Value, result.Content.Value);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodNutrientLogController_Put_UnsuccessfulInsert_DifferentFoodNutrientLog()
        {
            var currentFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 3,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };

            var updatedFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 2,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Get(2)).Returns(currentFoodNutrientLog);
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Update(updatedFoodNutrientLog));

            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);
            IHttpActionResult response =
                foodNutrientLogController.Put(updatedFoodNutrientLog.NurtientLogID, updatedFoodNutrientLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodNutrientLogController_Put_UnsuccessfulInsert_NoFoodNutrientLog()
        {
            var updatedFoodNutrientLog = new FoodNutrientLog
            {
                NurtientLogID = 2,
                FoodID = 101,
                NurtientID = 2,
                Value = 10
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Get(2));
            _unitOfWork.Setup(i => i.FoodNutrientLogRepository.Update(updatedFoodNutrientLog));

            var foodNutrientLogController = new FoodNutrientLogController(_unitOfWork.Object);
            IHttpActionResult response =
                foodNutrientLogController.Put(updatedFoodNutrientLog.NurtientLogID, updatedFoodNutrientLog).Result;
            var result = response as CreatedNegotiatedContentResult<FoodNutrientLog>;

            Assert.IsNull(result);
        }
    }
}