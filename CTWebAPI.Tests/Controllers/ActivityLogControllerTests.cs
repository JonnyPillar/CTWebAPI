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
    [TestFixture]
    internal class ActivityLogControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeActivityLog = GetActivityLog();
        }

        private IEnumerable<ActivityLog> _fakeActivityLog;
        private ActivityLogController _activityLogController;
        private Mock<IUnitOfWork> _unitOfWork;

        private IEnumerable<ActivityLog> GetActivityLog()
        {
            IEnumerable<ActivityLog> activityLogs = new List<ActivityLog>
            {
                new ActivityLog
                {
                    ActivityLogID = 0,
                    ActivityID = 1,
                    UserID = 8,
                    StartDate = DateTime.Now,
                    Duration = new TimeSpan(1, 12, 12),
                    Title = "Hello World",
                    Accent = (decimal) 10.0,
                    HeartRate = 180,
                    Notes = "",
                    FileURL = ""
                },
                new ActivityLog
                {
                    ActivityLogID = 1,
                    ActivityID = 1,
                    UserID = 8,
                    StartDate = DateTime.Now,
                    Duration = new TimeSpan(1, 12, 12),
                    Title = "Hello World",
                    Accent = (decimal) 10.0,
                    HeartRate = 180,
                    Notes = "",
                    FileURL = ""
                },
                new ActivityLog
                {
                    ActivityLogID = 2,
                    ActivityID = 1,
                    UserID = 8,
                    StartDate = DateTime.Now,
                    Duration = new TimeSpan(1, 12, 12),
                    Title = "Hello World",
                    Accent = (decimal) 10.0,
                    HeartRate = 180,
                    Notes = "",
                    FileURL = ""
                },
                new ActivityLog
                {
                    ActivityLogID = 3,
                    ActivityID = 1,
                    UserID = 8,
                    StartDate = DateTime.Now,
                    Duration = new TimeSpan(1, 12, 12),
                    Title = "Hello World",
                    Accent = (decimal) 10.0,
                    HeartRate = 180,
                    Notes = "",
                    FileURL = ""
                },
                new ActivityLog
                {
                    ActivityLogID = 4,
                    ActivityID = 1,
                    UserID = 8,
                    StartDate = DateTime.Now,
                    Duration = new TimeSpan(1, 12, 12),
                    Title = "Hello World",
                    Accent = (decimal) 10.0,
                    HeartRate = 180,
                    Notes = "",
                    FileURL = ""
                }
            }.AsEnumerable();
            return activityLogs;
        }

        [Test]
        public void ActivityLogController_Delete_DeletesActivityLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var activityLogToDelete = new ActivityLog
            {
                ActivityLogID = 0,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };

            _unitOfWork.Setup(x => x.ActivityLogRepository.Delete(activityLogToDelete));
            _activityLogController = new ActivityLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _activityLogController.Delete(activityLogToDelete).Result;
            var activityLog = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(activityLog);
        }

        [Test]
        public void ActivityLogController_Delete_NullActivityLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(x => x.ActivityLogRepository.Delete(null));
            _activityLogController = new ActivityLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _activityLogController.Delete(null).Result;
            var activityLog = actionResult as OkNegotiatedContentResult<string>;

            Assert.IsNull(activityLog);
        }

        [Test]
        public void ActivityLogController_GetRange_ReturnsActivityLogsInRange()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.ActivityLogRepository.GetRange(5)).Returns(_fakeActivityLog);
            var activityLogController = new ActivityLogController(_unitOfWork.Object);

            IEnumerable<ActivityLog> activityLogs = activityLogController.GetRange(5);
            Assert.AreEqual(_fakeActivityLog.Count(), activityLogs.Count());
        }

        [Test]
        public void ActivityLogController_Get_ReturnsAllActivityLogs()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.ActivityLogRepository.Get()).Returns(_fakeActivityLog);
            var activityLogController = new ActivityLogController(_unitOfWork.Object);

            IEnumerable<ActivityLog> activityLogs = activityLogController.Get();
            Assert.AreSame(_fakeActivityLog, activityLogs);
        }

        [Test]
        public void ActivityLogController_Get_ReturnsCorrectActivityLog()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            var expectedActivityLog = new ActivityLog
            {
                ActivityLogID = 0,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };
            _unitOfWork.Setup(x => x.ActivityLogRepository.GetAsync(2)).ReturnsAsync(expectedActivityLog);
            _activityLogController = new ActivityLogController(_unitOfWork.Object);

            IHttpActionResult actionResult = _activityLogController.Get(2).Result;
            var returnedActivityLog = actionResult as OkNegotiatedContentResult<ActivityLog>;

            Assert.IsNotNull(returnedActivityLog);
            Assert.AreSame(expectedActivityLog, returnedActivityLog.Content);
        }

        [Test]
        public void ActivityLogController_Get_ReturnsNotFound()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(x => x.ActivityLogRepository.Get(2));
            _activityLogController = new ActivityLogController(_unitOfWork.Object);

            IHttpActionResult response = _activityLogController.Get(2).Result;
            var returnedActivityLog = response as OkNegotiatedContentResult<ActivityLog>;

            Assert.IsNull(returnedActivityLog); //If null somethings gone wrong
        }

        [Test]
        public void ActivityLogController_Post_SuccessfulInsert()
        {
            var createdActivityLog = new ActivityLog
            {
                ActivityLogID = 1,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal)10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityLogRepository.Create(createdActivityLog));

            var activityLogController = new ActivityLogController(_unitOfWork.Object);
            IHttpActionResult response = activityLogController.Post(createdActivityLog).Result;
            var result = response as CreatedNegotiatedContentResult<ActivityLog>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActivityLog>(result.Content);
            Assert.AreEqual(createdActivityLog, result.Content);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void ActivityLogController_Post_UnsuccessfulInsert()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityLogRepository.Create(null));

            var activityLogController = new ActivityLogController(_unitOfWork.Object);
            IHttpActionResult response = activityLogController.Post(null).Result;
            var result = response as CreatedNegotiatedContentResult<ActivityLog>;

            Assert.IsNull(result);
        }

        [Test]
        public void ActivityLogController_Put_SuccessfulUpdate()
        {
            var currentActivityLog = new ActivityLog
            {
                ActivityLogID = 2,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };

            var updatedActivityLog = new ActivityLog
            {
                ActivityLogID = 2,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityLogRepository.Get(2)).Returns(currentActivityLog);
            _unitOfWork.Setup(i => i.ActivityLogRepository.Update(updatedActivityLog));

            var activityLogController = new ActivityLogController(_unitOfWork.Object);
            IHttpActionResult response =
                activityLogController.Put(updatedActivityLog.ActivityLogID, updatedActivityLog).Result;
            var result = response as CreatedNegotiatedContentResult<ActivityLog>;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActivityLog>(result.Content);
            Assert.AreEqual(updatedActivityLog, result.Content);
            Assert.AreEqual(updatedActivityLog.Distance, result.Content.Distance);
            Assert.IsNotNullOrEmpty(result.Location.ToString());
        }

        [Test]
        public void ActivityLogController_Put_UnsuccessfulInsert_DifferentActivityLog()
        {
            var currentActivityLog = new ActivityLog
            {
                ActivityLogID = 3,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };

            var updatedActivityLog = new ActivityLog
            {
                ActivityLogID = 2,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityLogRepository.Get(2)).Returns(currentActivityLog);
            _unitOfWork.Setup(i => i.ActivityLogRepository.Update(updatedActivityLog));

            var activityLogController = new ActivityLogController(_unitOfWork.Object);
            IHttpActionResult response =
                activityLogController.Put(updatedActivityLog.ActivityLogID, updatedActivityLog).Result;
            var result = response as CreatedNegotiatedContentResult<ActivityLog>;

            Assert.IsNull(result);
        }

        [Test]
        public void ActivityLogController_Put_UnsuccessfulInsert_NoActivityLog()
        {
            var updatedActivityLog = new ActivityLog
            {
                ActivityLogID = 2,
                ActivityID = 1,
                UserID = 8,
                StartDate = DateTime.Now,
                Duration = new TimeSpan(1, 12, 12),
                Title = "Hello World",
                Accent = (decimal) 10.0,
                HeartRate = 180,
                Notes = "",
                FileURL = ""
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(i => i.ActivityLogRepository.Get(2));
            _unitOfWork.Setup(i => i.ActivityLogRepository.Update(updatedActivityLog));

            var activityLogController = new ActivityLogController(_unitOfWork.Object);
            IHttpActionResult response =
                activityLogController.Put(updatedActivityLog.ActivityLogID, updatedActivityLog).Result;
            var result = response as CreatedNegotiatedContentResult<ActivityLog>;

            Assert.IsNull(result);
        }
    }
}