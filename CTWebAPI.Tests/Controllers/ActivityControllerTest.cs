using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using CTWebAPI.Controllers;
using CTWebAPI.Models;
using CTWebAPI.Models.DomainModels;
using CTWebAPI.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace CTWebAPI.Tests.Controllers
{
    [TestFixture]
    public class ActivityControllerTest
    {
        [SetUp]
        public void SetUp()
        {
            _fakeActivity = GetActivites();
        }

        private IEnumerable<Activity> _fakeActivity;
        private ActivityController _activityController;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<Activity> GetActivites()
        {
            IEnumerable<Activity> activities = new List<Activity>
            {
                new Activity
                {
                    ActivityID = 0,
                    Name = "Activity Zero",
                    CalorieBurnRate = 10,
                    ImageUrl = ""
                },
                new Activity
                {
                    ActivityID = 1,
                    Name = "Activity One",
                    CalorieBurnRate = 10,
                    ImageUrl = ""
                },
                new Activity
                {
                    ActivityID = 2,
                    Name = "Activity Two",
                    CalorieBurnRate = 10,
                    ImageUrl = ""
                },
                new Activity
                {
                    ActivityID = 3,
                    Name = "Activity Three",
                    CalorieBurnRate = 10,
                    ImageUrl = ""
                },
                new Activity
                {
                    ActivityID = 4,
                    Name = "Activity Four",
                    CalorieBurnRate = 10,
                    ImageUrl = ""
                },
            }.AsEnumerable();
            return activities;
        }

        [Test]
        public void ActivityController_Get_ReturnsAllActivitys()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.ActivityRepository.Get()).Returns(_fakeActivity);
            var activityController = new ActivityController(_unitOfWork.Object);

            IEnumerable<Activity> activities = activityController.Get();
            Assert.AreSame(_fakeActivity, activities);
        }

        [Test]
        public void ActivityController_Get_ReturnsCorrectActivity()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedActivity = new Activity
            {
                ActivityID = 0,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };
            _unitOfWork.Setup(x => x.ActivityRepository.GetAsync(2)).ReturnsAsync(expectedActivity);
            _activityController = new ActivityController(_unitOfWork.Object);

            IHttpActionResult actionResult = _activityController.Get(2).Result;
            var returnedActivity = actionResult as OkNegotiatedContentResult<Activity>;

            Assert.IsNotNull(returnedActivity);
            Assert.AreSame(expectedActivity, returnedActivity.Content);
        }

        [Test]
        public void ActivityController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.ActivityRepository.Get(2));
            _activityController = new ActivityController(_unitOfWork.Object);

            IHttpActionResult response = _activityController.Get(2).Result;
            var returnedActivity = response as OkNegotiatedContentResult<Activity>;

            Assert.IsNull(returnedActivity); //If null somethings gone wrong
        }

        [Test]
        public void ActivityController_Post_SuccessfulInsert()
        {
            var createdActivity = new Activity
            {
                ActivityID = 1,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityRepository.Create(createdActivity));

            var activityController = new ActivityController(_unitOfWork.Object);
            IHttpActionResult response = activityController.Post(createdActivity).Result;
            var result = response as CreatedNegotiatedContentResult<Activity>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Activity>(result.Content);
            Assert.AreEqual(createdActivity, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void ActivityController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityRepository.Create(null));

            var activityController = new ActivityController(_unitOfWork.Object);
            IHttpActionResult response = activityController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<Activity>;

            Assert.IsNull(result);
        }

        [Test]
        public void ActivityController_Put_SuccessfulUpdate()
        {
            var currentActivity = new Activity
            {
                ActivityID = 2,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };

            var updatedActivity = new Activity
            {
                ActivityID = 2,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityRepository.Get(2)).Returns(currentActivity);
            _unitOfWork.Setup(i => i.ActivityRepository.Update(updatedActivity));

            var activityController = new ActivityController(_unitOfWork.Object);
            IHttpActionResult response = activityController.Put(updatedActivity.ActivityID, updatedActivity).Result;
            var result = response as CreatedNegotiatedContentResult<Activity>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Activity>(result.Content);
            Assert.AreEqual(updatedActivity, result.Content);
            Assert.AreEqual(updatedActivity.Name, result.Content.Name);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void ActivityController_Put_UnsuccessfulInsert_DifferentActivity()
        {
            var currentActivity = new Activity
            {
                ActivityID = 3,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };

            var updatedActivity = new Activity
            {
                ActivityID = 2,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityRepository.Get(2)).Returns(currentActivity);
            _unitOfWork.Setup(i => i.ActivityRepository.Update(updatedActivity));

            var activityController = new ActivityController(_unitOfWork.Object);
            IHttpActionResult response = activityController.Put(updatedActivity.ActivityID, updatedActivity).Result;
            var result = response as CreatedNegotiatedContentResult<Activity>;

            Assert.IsNull(result);
        }

        [Test]
        public void ActivityController_Put_UnsuccessfulInsert_NoActivity()
        {
            var updatedActivity = new Activity
            {
                ActivityID = 2,
                Name = "Activity One",
                CalorieBurnRate = 10,
                ImageUrl = ""
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityRepository.Get(2));
            _unitOfWork.Setup(i => i.ActivityRepository.Update(updatedActivity));

            var activityController = new ActivityController(_unitOfWork.Object);
            IHttpActionResult response = activityController.Put(updatedActivity.ActivityID, updatedActivity).Result;
            var result = response as CreatedNegotiatedContentResult<Activity>;

            Assert.IsNull(result);
        }
    }
}