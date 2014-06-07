using System;
using System.Collections.Generic;
using System.Linq;
using CTWebAPI.Controllers;
using CTWebAPI.Models;
using CTWebAPI.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace CTWebAPI.Tests
{
    [TestFixture]
    public class FoodControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakeUsers = GetFood();
        }

        private IEnumerable<Food> _fakeUsers;
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
        public void TestMethod1()
        {

        }
    }
}
