using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Користувач.
    /// </summary>
    public class User
    {
        #region Властивості
        /// <summary>
        /// Ім'я.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Стать.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вага.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Ріст.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Створити нового користувача.
        /// </summary>
        /// <param name="name"> Ім'я. </param>
        /// <param name="gender"> Стать. </param>
        /// <param name="birthDate"> Дата народження. </param>
        /// <param name="weight"> Вага. </param>
        /// <param name="height"> Ріст. </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Перевірка умов
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Ім'я користувача не можу бути пустим чи null.", nameof(name));
            }

            if (gender is null)
            {
                throw new ArgumentNullException("Стать не можу бути null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Неможлива дата народження.", nameof(birthDate));
            }

            if (weight <= 0 )
            {
                throw new ArgumentException("Вага не може бути менше менше чи рівний нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Ріст не може бути менше менше чи рівний нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}