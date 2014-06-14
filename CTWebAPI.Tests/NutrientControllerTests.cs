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
    internal class NutrientControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeNutrient = GetNutrient();
        }

        private IEnumerable<Nutrient> _fakeNutrient;
        private NutrientController _nutrientController;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<Nutrient> GetNutrient()
        {
            IEnumerable<Nutrient> nutrients = new List<Nutrient>
            {
                new Nutrient
                {
                    NutrientID = 0,
                    SourceID = 0,
                    Name = "Nutrient 0",
                    DecimalRounding = 0,
                    UnitType = 0
                },
                new Nutrient
                {
                    NutrientID = 1,
                    SourceID = 1,
                    Name = "Nutrient 1",
                    DecimalRounding = 0,
                    UnitType = 0
                },
                new Nutrient
                {
                    NutrientID = 2,
                    SourceID = 2,
                    Name = "Nutrient 2",
                    DecimalRounding = 0,
                    UnitType = 0
                },
                new Nutrient
                {
                    NutrientID = 3,
                    SourceID = 3,
                    Name = "Nutrient 3",
                    DecimalRounding = 0,
                    UnitType = 0
                },
                new Nutrient
                {
                    NutrientID = 4,
                    SourceID = 4,
                    Name = "Nutrient 4",
                    DecimalRounding = 0,
                    UnitType = 0
                }
            }.AsEnumerable();
            return nutrients;
        }

        [Test]
        public void NutrientController_Delete_DeletesNutrient()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var nutrientToDelete = new Nutrient
            {
                NutrientID = 0,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };

            _unitOfWork.Setup(x => x.NutrientRepository.Delete(nutrientToDelete));
            _nutrientController = new NutrientController(_unitOfWork.Object);

            IHttpActionResult actionResult = _nutrientController.Delete(nutrientToDelete).Result;
            var nutrient = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(nutrient);
        }

        [Test]
        public void NutrientController_Delete_NullNutrient()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.NutrientRepository.Delete(null));
            _nutrientController = new NutrientController(_unitOfWork.Object);

            IHttpActionResult actionResult = _nutrientController.Delete(null).Result;
            var nutrient = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(nutrient);
        }

        [Test]
        public void NutrientController_GetRange_ReturnsNutrientsInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.NutrientRepository.GetRange(5)).Returns(_fakeNutrient);
            var nutrientController = new NutrientController(_unitOfWork.Object);

            IEnumerable<Nutrient> nutrients = nutrientController.GetRange(5);
            Assert.AreEqual(_fakeNutrient.Count(), nutrients.Count());
        }

        [Test]
        public void NutrientController_Get_ReturnsAllNutrients()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.NutrientRepository.Get()).Returns(_fakeNutrient);
            var nutrientController = new NutrientController(_unitOfWork.Object);

            IEnumerable<Nutrient> nutrients = nutrientController.Get();
            Assert.AreSame(_fakeNutrient, nutrients);
        }

        [Test]
        public void NutrientController_Get_ReturnsCorrectNutrient()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedNutrient = new Nutrient
            {
                NutrientID = 0,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };
            _unitOfWork.Setup(x => x.NutrientRepository.GetAsync(2)).ReturnsAsync(expectedNutrient);
            _nutrientController = new NutrientController(_unitOfWork.Object);

            IHttpActionResult actionResult = _nutrientController.Get(2).Result;
            var returnedNutrient = actionResult as OkNegotiatedContentResult<Nutrient>;

            Assert.IsNotNull(returnedNutrient);
            Assert.AreSame(expectedNutrient, returnedNutrient.Content);
        }

        [Test]
        public void NutrientController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.NutrientRepository.Get(2));
            _nutrientController = new NutrientController(_unitOfWork.Object);

            IHttpActionResult response = _nutrientController.Get(2).Result;
            var returnedNutrient = response as OkNegotiatedContentResult<Nutrient>;

            Assert.IsNull(returnedNutrient); //If null somethings gone wrong
        }

        [Test]
        public void NutrientController_Post_SuccessfulInsert()
        {
            var createdNutrient = new Nutrient
            {
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRepository.Create(createdNutrient));

            var nutrientController = new NutrientController(_unitOfWork.Object);
            IHttpActionResult response = nutrientController.Post(createdNutrient).Result;
            var result = response as CreatedNegotiatedContentResult<Nutrient>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Nutrient>(result.Content);
            Assert.AreEqual(createdNutrient, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void NutrientController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRepository.Create(null));

            var nutrientController = new NutrientController(_unitOfWork.Object);
            IHttpActionResult response = nutrientController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<Nutrient>;

            Assert.IsNull(result);
        }

        [Test]
        public void NutrientController_Put_SuccessfulUpdate()
        {
            var currentNutrient = new Nutrient
            {
                NutrientID = 2,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };

            var updatedNutrient = new Nutrient
            {
                NutrientID = 2,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRepository.Get(2)).Returns(currentNutrient);
            _unitOfWork.Setup(i => i.NutrientRepository.Update(updatedNutrient));

            var nutrientController = new NutrientController(_unitOfWork.Object);
            IHttpActionResult response = nutrientController.Put(updatedNutrient.NutrientID, updatedNutrient).Result;
            var result = response as CreatedNegotiatedContentResult<Nutrient>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Nutrient>(result.Content);
            Assert.AreEqual(updatedNutrient, result.Content);
            Assert.AreEqual(updatedNutrient.Name, result.Content.Name);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void NutrientController_Put_UnsuccessfulInsert_DifferentNutrient()
        {
            var currentNutrient = new Nutrient
            {
                NutrientID = 3,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };

            var updatedNutrient = new Nutrient
            {
                NutrientID = 2,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRepository.Get(2)).Returns(currentNutrient);
            _unitOfWork.Setup(i => i.NutrientRepository.Update(updatedNutrient));

            var nutrientController = new NutrientController(_unitOfWork.Object);
            IHttpActionResult response = nutrientController.Put(updatedNutrient.NutrientID, updatedNutrient).Result;
            var result = response as CreatedNegotiatedContentResult<Nutrient>;

            Assert.IsNull(result);
        }

        [Test]
        public void NutrientController_Put_UnsuccessfulInsert_NoNutrient()
        {
            var updatedNutrient = new Nutrient
            {
                NutrientID = 2,
                SourceID = 0,
                Name = "Nutrient 0",
                DecimalRounding = 0,
                UnitType = 0
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRepository.Get(2));
            _unitOfWork.Setup(i => i.NutrientRepository.Update(updatedNutrient));

            var nutrientController = new NutrientController(_unitOfWork.Object);
            IHttpActionResult response = nutrientController.Put(updatedNutrient.NutrientID, updatedNutrient).Result;
            var result = response as CreatedNegotiatedContentResult<Nutrient>;

            Assert.IsNull(result);
        }
    }
}