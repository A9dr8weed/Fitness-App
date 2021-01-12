using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            DateTime birthDate = DateTime.Now.AddYears(-19);
            double weight = 90;
            double height = 190;
            string gender = "man";
            UserController controller = new UserController(userName);

            // Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            UserController controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange - оголошення - дані які подаємо на вхід, і які будуть оброблятися на виході
            string userName = Guid.NewGuid().ToString();

            // Act - дія (виклик)
            UserController controller = new UserController(userName);

            // Assert - перевірка того що вийшло, і того що очікувалося
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}