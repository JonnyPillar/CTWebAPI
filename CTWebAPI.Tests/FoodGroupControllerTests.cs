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
    internal class FoodGroupControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeFoodGroup = GetFoodGroup();
        }

        private IEnumerable<FoodGroup> _fakeFoodGroup;
        private FoodGroupController _foodGroupController;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<FoodGroup> GetFoodGroup()
        {
            IEnumerable<FoodGroup> foodGroups = new List<FoodGroup>
            {
                new FoodGroup
                {
                    FoodGroupID = 0,
                    SourceID = 0,
                    Name = "FoodGroup 0",
                },
                new FoodGroup
                {
                    FoodGroupID = 1,
                    SourceID = 1,
                    Name = "FoodGroup 1",
                },
                new FoodGroup
                {
                    FoodGroupID = 2,
                    SourceID = 2,
                    Name = "FoodGroup 2",
                },
                new FoodGroup
                {
                    FoodGroupID = 3,
                    SourceID = 3,
                    Name = "FoodGroup 3",
                },
                new FoodGroup
                {
                    FoodGroupID = 4,
                    SourceID = 4,
                    Name = "FoodGroup 4",
                }
            }.AsEnumerable();
            return foodGroups;
        }

        [Test]
        public void FoodGroupController_Delete_DeletesFoodGroup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var foodGroupToDelete = new FoodGroup
            {
                FoodGroupID = 0,
                SourceID = 0,
                Name = "FoodGroup 0",
            };

            _unitOfWork.Setup(x => x.FoodGroupRepository.Delete(foodGroupToDelete));
            _foodGroupController = new FoodGroupController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodGroupController.Delete(foodGroupToDelete).Result;
            var FoodGroup = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(FoodGroup);
        }

        [Test]
        public void FoodGroupController_Delete_NullFoodGroup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.FoodGroupRepository.Delete(null));
            _foodGroupController = new FoodGroupController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodGroupController.Delete(null).Result;
            var FoodGroup = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(FoodGroup);
        }

        [Test]
        public void FoodGroupController_GetRange_ReturnsFoodGroupsInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodGroupRepository.GetRange(5)).Returns(_fakeFoodGroup);
            var foodGroupController = new FoodGroupController(_unitOfWork.Object);

            IEnumerable<FoodGroup> FoodGroups = foodGroupController.GetRange(5);
            Assert.AreEqual(_fakeFoodGroup.Count(), FoodGroups.Count());
        }

        [Test]
        public void FoodGroupController_Get_ReturnsAllFoodGroups()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodGroupRepository.Get()).Returns(_fakeFoodGroup);
            var foodGroupController = new FoodGroupController(_unitOfWork.Object);

            IEnumerable<FoodGroup> FoodGroups = foodGroupController.Get();
            Assert.AreSame(_fakeFoodGroup, FoodGroups);
        }

        [Test]
        public void FoodGroupController_Get_ReturnsCorrectFoodGroup()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedFoodGroup = new FoodGroup
            {
                FoodGroupID = 0,
                SourceID = 0,
                Name = "FoodGroup 0",
            };
            _unitOfWork.Setup(x => x.FoodGroupRepository.GetAsync(2)).ReturnsAsync(expectedFoodGroup);
            _foodGroupController = new FoodGroupController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodGroupController.Get(2).Result;
            var returnedFoodGroup = actionResult as OkNegotiatedContentResult<FoodGroup>;

            Assert.IsNotNull(returnedFoodGroup);
            Assert.AreSame(expectedFoodGroup, returnedFoodGroup.Content);
        }

        [Test]
        public void FoodGroupController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodGroupRepository.Get(2));
            _foodGroupController = new FoodGroupController(_unitOfWork.Object);

            IHttpActionResult response = _foodGroupController.Get(2).Result;
            var returnedFoodGroup = response as OkNegotiatedContentResult<FoodGroup>;

            Assert.IsNull(returnedFoodGroup); //If null somethings gone wrong
        }

        [Test]
        public void FoodGroupController_Post_SuccessfulInsert()
        {
            var createdFoodGroup = new FoodGroup();
            createdFoodGroup.FoodGroupID = 1;
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodGroupRepository.Create(createdFoodGroup));

            var foodGroupController = new FoodGroupController(_unitOfWork.Object);
            IHttpActionResult response = foodGroupController.Post(createdFoodGroup).Result;
            var result = response as CreatedNegotiatedContentResult<FoodGroup>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FoodGroup>(result.Content);
            Assert.AreEqual(createdFoodGroup, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodGroupController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodGroupRepository.Create(null));

            var foodGroupController = new FoodGroupController(_unitOfWork.Object);
            IHttpActionResult response = foodGroupController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<FoodGroup>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodGroupController_Put_SuccessfulUpdate()
        {
            var currentFoodGroup = new FoodGroup();
            currentFoodGroup.FoodGroupID = 2;
            currentFoodGroup.Name = "FoodGroup One";

            var updatedFoodGroup = new FoodGroup();
            updatedFoodGroup.FoodGroupID = 2;
            updatedFoodGroup.Name = "FoodGroup One";

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodGroupRepository.Get(2)).Returns(currentFoodGroup);
            _unitOfWork.Setup(i => i.FoodGroupRepository.Update(updatedFoodGroup));

            var foodGroupController = new FoodGroupController(_unitOfWork.Object);
            IHttpActionResult response = foodGroupController.Put(updatedFoodGroup.FoodGroupID, updatedFoodGroup).Result;
            var result = response as CreatedNegotiatedContentResult<FoodGroup>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<FoodGroup>(result.Content);
            Assert.AreEqual(updatedFoodGroup, result.Content);
            Assert.AreEqual(updatedFoodGroup.Name, result.Content.Name);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodGroupController_Put_UnsuccessfulInsert_DifferentFoodGroup()
        {
            var currentFoodGroup = new FoodGroup();
            currentFoodGroup.FoodGroupID = 3;
            currentFoodGroup.Name = "FoodGroup One";

            var updatedFoodGroup = new FoodGroup();
            updatedFoodGroup.FoodGroupID = 2;
            updatedFoodGroup.Name = "FoodGroup One";

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodGroupRepository.Get(2)).Returns(currentFoodGroup);
            _unitOfWork.Setup(i => i.FoodGroupRepository.Update(updatedFoodGroup));

            var foodGroupController = new FoodGroupController(_unitOfWork.Object);
            IHttpActionResult response = foodGroupController.Put(updatedFoodGroup.FoodGroupID, updatedFoodGroup).Result;
            var result = response as CreatedNegotiatedContentResult<FoodGroup>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodGroupController_Put_UnsuccessfulInsert_NoFoodGroup()
        {
            var updatedFoodGroup = new FoodGroup();
            updatedFoodGroup.FoodGroupID = 2;
            updatedFoodGroup.Name = "FoodGroup One";

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodGroupRepository.Get(2));
            _unitOfWork.Setup(i => i.FoodGroupRepository.Update(updatedFoodGroup));

            var foodGroupController = new FoodGroupController(_unitOfWork.Object);
            IHttpActionResult response = foodGroupController.Put(updatedFoodGroup.FoodGroupID, updatedFoodGroup).Result;
            var result = response as CreatedNegotiatedContentResult<FoodGroup>;

            Assert.IsNull(result);
        }
    }
}