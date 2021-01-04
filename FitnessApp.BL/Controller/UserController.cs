using FitnessApp.BL.Model;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер користувача.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Користувач додатка.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Створення нового користувача.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            Gender gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Отримати користувача.
        /// </summary>
        /// <returns> Користувач додатку. </returns>
        public UserController()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }

        /// <summary>
        /// Зберегти дані користувача.
        /// </summary>
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}