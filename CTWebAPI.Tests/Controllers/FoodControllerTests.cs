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
    public class FoodControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeFood = GetFood();
        }

        private IEnumerable<Food> _fakeFood;
        private FoodController _foodController;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<Food> GetFood()
        {
            IEnumerable<Food> foods = new List<Food>
            {
                new Food
                {
                    FoodID = 0,
                    SourceID = 0,
                    GroupID = 1,
                    Name = "Food 0",
                    Description = "",
                    ManufactureName = ""
                },
                new Food
                {
                    FoodID = 1,
                    SourceID = 1,
                    GroupID = 1,
                    Name = "Food 1",
                    Description = "",
                    ManufactureName = ""
                },
                new Food
                {
                    FoodID = 2,
                    SourceID = 2,
                    GroupID = 2,
                    Name = "Food 2",
                    Description = "",
                    ManufactureName = ""
                },
                new Food
                {
                    FoodID = 3,
                    SourceID = 3,
                    GroupID = 3,
                    Name = "Food 3",
                    Description = "",
                    ManufactureName = ""
                },
                new Food
                {
                    FoodID = 4,
                    SourceID = 4,
                    GroupID = 3,
                    Name = "Food 4",
                    Description = "",
                    ManufactureName = ""
                }
            }.AsEnumerable();
            return foods;
        }

        [Test]
        public void FoodController_Delete_DeletesFood()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var foodToDelete = new Food
            {
                FoodID = 0,
                SourceID = 0,
                GroupID = 1,
                Name = "Food 0",
                Description = "",
                ManufactureName = ""
            };

            _unitOfWork.Setup(x => x.FoodRepository.Delete(foodToDelete));
            _foodController = new FoodController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodController.Delete(foodToDelete).Result;
            var Food = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(Food);
        }

        [Test]
        public void FoodController_Delete_NullFood()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.FoodRepository.Delete(null));
            _foodController = new FoodController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodController.Delete(null).Result;
            var Food = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(Food);
        }

        [Test]
        public void FoodController_GetRange_ReturnsFoodsInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodRepository.GetRange(5)).Returns(_fakeFood);
            var foodController = new FoodController(_unitOfWork.Object);

            IEnumerable<Food> Foods = foodController.GetRange(5);
            Assert.AreEqual(_fakeFood.Count(), Foods.Count());
        }

        [Test]
        public void FoodController_Get_ReturnsAllFoods()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodRepository.Get()).Returns(_fakeFood);
            var foodController = new FoodController(_unitOfWork.Object);

            IEnumerable<Food> Foods = foodController.Get();
            Assert.AreSame(_fakeFood, Foods);
        }

        [Test]
        public void FoodController_Get_ReturnsCorrectFood()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedFood = new Food
            {
                FoodID = 0,
                SourceID = 0,
                GroupID = 1,
                Name = "Food 0",
                Description = "",
                ManufactureName = ""
            };
            _unitOfWork.Setup(x => x.FoodRepository.GetAsync(2)).ReturnsAsync(expectedFood);
            _foodController = new FoodController(_unitOfWork.Object);

            IHttpActionResult actionResult = _foodController.Get(2).Result;
            var returnedFood = actionResult as OkNegotiatedContentResult<Food>;

            Assert.IsNotNull(returnedFood);
            Assert.AreSame(expectedFood, returnedFood.Content);
        }

        [Test]
        public void FoodController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.FoodRepository.Get(2));
            _foodController = new FoodController(_unitOfWork.Object);

            IHttpActionResult response = _foodController.Get(2).Result;
            var returnedFood = response as OkNegotiatedContentResult<Food>;

            Assert.IsNull(returnedFood); //If null somethings gone wrong
        }

        [Test]
        public void FoodController_Post_SuccessfulInsert()
        {
            var createdFood = new Food();
            createdFood.FoodID = 1;
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodRepository.Create(createdFood));

            var foodController = new FoodController(_unitOfWork.Object);
            IHttpActionResult response = foodController.Post(createdFood).Result;
            var result = response as CreatedNegotiatedContentResult<Food>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Food>(result.Content);
            Assert.AreEqual(createdFood, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodRepository.Create(null));

            var foodController = new FoodController(_unitOfWork.Object);
            IHttpActionResult response = foodController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<Food>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodController_Put_SuccessfulUpdate()
        {
            var currentFood = new Food();
            currentFood.FoodID = 2;
            currentFood.Name = "Food One";

            var updatedFood = new Food();
            updatedFood.FoodID = 2;
            updatedFood.Name = "Food One";

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodRepository.Get(2)).Returns(currentFood);
            _unitOfWork.Setup(i => i.FoodRepository.Update(updatedFood));

            var foodController = new FoodController(_unitOfWork.Object);
            IHttpActionResult response = foodController.Put(updatedFood.FoodID, updatedFood).Result;
            var result = response as CreatedNegotiatedContentResult<Food>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Food>(result.Content);
            Assert.AreEqual(updatedFood, result.Content);
            Assert.AreEqual(updatedFood.Name, result.Content.Name);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void FoodController_Put_UnsuccessfulInsert_DifferentFood()
        {
            var currentFood = new Food();
            currentFood.FoodID = 3;
            currentFood.Name = "Food One";

            var updatedFood = new Food();
            updatedFood.FoodID = 2;
            updatedFood.Name = "Food One";

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodRepository.Get(2)).Returns(currentFood);
            _unitOfWork.Setup(i => i.FoodRepository.Update(updatedFood));

            var foodController = new FoodController(_unitOfWork.Object);
            IHttpActionResult response = foodController.Put(updatedFood.FoodID, updatedFood).Result;
            var result = response as CreatedNegotiatedContentResult<Food>;

            Assert.IsNull(result);
        }

        [Test]
        public void FoodController_Put_UnsuccessfulInsert_NoFood()
        {
            var updatedFood = new Food();
            updatedFood.FoodID = 2;
            updatedFood.Name = "Food One";

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.FoodRepository.Get(2));
            _unitOfWork.Setup(i => i.FoodRepository.Update(updatedFood));

            var foodController = new FoodController(_unitOfWork.Object);
            IHttpActionResult response = foodController.Put(updatedFood.FoodID, updatedFood).Result;
            var result = response as CreatedNegotiatedContentResult<Food>;

            Assert.IsNull(result);
        }
    }
}