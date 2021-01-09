using FitnessApp.BL.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            string foodName = Guid.NewGuid().ToString();
            Random rnd = new Random();

            UserController userController = new UserController(userName);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            Food food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}