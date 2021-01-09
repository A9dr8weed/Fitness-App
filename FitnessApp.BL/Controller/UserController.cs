using FitnessApp.BL.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер користувача.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";

        /// <summary>
        /// Користувач додатка.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Створення нового користувача.
        /// </summary>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Ім'я користувача не може бути пустим", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(x => x.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Отримати збережений список користувачів.
        /// </summary>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Зберегти дані користувача.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }
    }
}