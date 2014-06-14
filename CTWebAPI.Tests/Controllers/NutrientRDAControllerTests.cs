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
    internal class NutrientRDAControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeNutrientRDA = GetNutrientRDA();
        }

        private IEnumerable<NutrientRDA> _fakeNutrientRDA;
        private NutrientRDAController _nutrientRDAController;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<NutrientRDA> GetNutrientRDA()
        {
            IEnumerable<NutrientRDA> nutrientRDAs = new List<NutrientRDA>
            {
                new NutrientRDA
                {
                    NutrientRDAID = 0,
                    Gender = true,
                    AgeMin = 10,
                    AgeMax = 20,
                    Value = 10,
                    UnitType = 0
                },
                new NutrientRDA
                {
                    NutrientRDAID = 1,
                    Gender = true,
                    AgeMin = 10,
                    AgeMax = 20,
                    Value = 10,
                    UnitType = 0
                },
                new NutrientRDA
                {
                    NutrientRDAID = 2,
                    Gender = true,
                    AgeMin = 10,
                    AgeMax = 20,
                    Value = 10,
                    UnitType = 0
                },
                new NutrientRDA
                {
                    NutrientRDAID = 3,
                    Gender = true,
                    AgeMin = 10,
                    AgeMax = 20,
                    Value = 10,
                    UnitType = 0
                },
                new NutrientRDA
                {
                    NutrientRDAID = 4,
                    Gender = true,
                    AgeMin = 10,
                    AgeMax = 20,
                    Value = 10,
                    UnitType = 0
                }
            }.AsEnumerable();
            return nutrientRDAs;
        }

        [Test]
        public void NutrientRDAController_Delete_DeletesNutrientRDA()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var nutrientRDAToDelete = new NutrientRDA
            {
                NutrientRDAID = 0,
                Gender = true,
                AgeMin = 10,
                AgeMax = 20,
                Value = 10,
                UnitType = 0
            };

            _unitOfWork.Setup(x => x.NutrientRDARepository.Delete(nutrientRDAToDelete));
            _nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);

            IHttpActionResult actionResult = _nutrientRDAController.Delete(nutrientRDAToDelete).Result;
            var NutrientRDA = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(NutrientRDA);
        }

        [Test]
        public void NutrientRDAController_Delete_NullNutrientRDA()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.NutrientRDARepository.Delete(null));
            _nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);

            IHttpActionResult actionResult = _nutrientRDAController.Delete(null).Result;
            var NutrientRDA = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(NutrientRDA);
        }

        [Test]
        public void NutrientRDAController_GetRange_ReturnsNutrientRDAsInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.NutrientRDARepository.GetRange(5)).Returns(_fakeNutrientRDA);
            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);

            IEnumerable<NutrientRDA> NutrientRDAs = nutrientRDAController.GetRange(5);
            Assert.AreEqual(_fakeNutrientRDA.Count(), NutrientRDAs.Count());
        }

        [Test]
        public void NutrientRDAController_Get_ReturnsAllNutrientRDAs()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.NutrientRDARepository.Get()).Returns(_fakeNutrientRDA);
            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);

            IEnumerable<NutrientRDA> NutrientRDAs = nutrientRDAController.Get();
            Assert.AreSame(_fakeNutrientRDA, NutrientRDAs);
        }

        [Test]
        public void NutrientRDAController_Get_ReturnsCorrectNutrientRDA()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedNutrientRDA = new NutrientRDA
            {
                NutrientRDAID = 0,
                Gender = true,
                AgeMin = 10,
                AgeMax = 20,
                Value = 10,
                UnitType = 0
            };
            _unitOfWork.Setup(x => x.NutrientRDARepository.GetAsync(2)).ReturnsAsync(expectedNutrientRDA);
            _nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);

            IHttpActionResult actionResult = _nutrientRDAController.Get(2).Result;
            var returnedNutrientRDA = actionResult as OkNegotiatedContentResult<NutrientRDA>;

            Assert.IsNotNull(returnedNutrientRDA);
            Assert.AreSame(expectedNutrientRDA, returnedNutrientRDA.Content);
        }

        [Test]
        public void NutrientRDAController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.NutrientRDARepository.Get(2));
            _nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);

            IHttpActionResult response = _nutrientRDAController.Get(2).Result;
            var returnedNutrientRDA = response as OkNegotiatedContentResult<NutrientRDA>;

            Assert.IsNull(returnedNutrientRDA); //If null somethings gone wrong
        }

        [Test]
        public void NutrientRDAController_Post_SuccessfulInsert()
        {
            var createdNutrientRDA = new NutrientRDA();
            createdNutrientRDA.NutrientRDAID = 1;
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRDARepository.Create(createdNutrientRDA));

            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);
            IHttpActionResult response = nutrientRDAController.Post(createdNutrientRDA).Result;
            var result = response as CreatedNegotiatedContentResult<NutrientRDA>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NutrientRDA>(result.Content);
            Assert.AreEqual(createdNutrientRDA, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void NutrientRDAController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRDARepository.Create(null));

            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);
            IHttpActionResult response = nutrientRDAController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<NutrientRDA>;

            Assert.IsNull(result);
        }

        [Test]
        public void NutrientRDAController_Put_SuccessfulUpdate()
        {
            var currentNutrientRDA = new NutrientRDA
            {
                NutrientRDAID = 2,
                Gender = true,
                AgeMin = 10,
                AgeMax = 20,
                Value = 10,
                UnitType = 0
            };

            var updatedNutrientRDA = new NutrientRDA
            {
                NutrientRDAID = 2,
                Gender = true,
                AgeMin = 10,
                AgeMax = 20,
                Value = 10,
                UnitType = 0
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRDARepository.Get(2)).Returns(currentNutrientRDA);
            _unitOfWork.Setup(i => i.NutrientRDARepository.Update(updatedNutrientRDA));

            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);
            IHttpActionResult response = nutrientRDAController.Put(updatedNutrientRDA.NutrientRDAID, updatedNutrientRDA).Result;
            var result = response as CreatedNegotiatedContentResult<NutrientRDA>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NutrientRDA>(result.Content);
            Assert.AreEqual(updatedNutrientRDA, result.Content);
            Assert.AreEqual(updatedNutrientRDA.AgeMax, result.Content.AgeMax);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void NutrientRDAController_Put_UnsuccessfulInsert_DifferentNutrientRDA()
        {
            var currentNutrientRDA = new NutrientRDA
            {
                NutrientRDAID = 3,
                Gender = true,
                AgeMin = 10,
                AgeMax = 20,
                Value = 10,
                UnitType = 0
            };

            var updatedNutrientRDA = new NutrientRDA
            {
                NutrientRDAID = 2,
                Gender = true,
                AgeMin = 10,
                AgeMax = 20,
                Value = 10,
                UnitType = 0
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRDARepository.Get(2)).Returns(currentNutrientRDA);
            _unitOfWork.Setup(i => i.NutrientRDARepository.Update(updatedNutrientRDA));

            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);
            IHttpActionResult response = nutrientRDAController.Put(updatedNutrientRDA.NutrientRDAID, updatedNutrientRDA).Result;
            var result = response as CreatedNegotiatedContentResult<NutrientRDA>;

            Assert.IsNull(result);
        }

        [Test]
        public void NutrientRDAController_Put_UnsuccessfulInsert_NoNutrientRDA()
        {
            var updatedNutrientRDA = new NutrientRDA {
                    NutrientRDAID = 2, 
                    Gender = true,
                    AgeMin = 10,
                    AgeMax = 20,
                    Value = 10,
                    UnitType = 0
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.NutrientRDARepository.Get(2));
            _unitOfWork.Setup(i => i.NutrientRDARepository.Update(updatedNutrientRDA));

            var nutrientRDAController = new NutrientRDAController(_unitOfWork.Object);
            IHttpActionResult response = nutrientRDAController.Put(updatedNutrientRDA.NutrientRDAID, updatedNutrientRDA).Result;
            var result = response as CreatedNegotiatedContentResult<NutrientRDA>;

            Assert.IsNull(result);
        }
    }
}