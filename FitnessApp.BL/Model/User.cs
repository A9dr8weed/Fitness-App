using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Користувач.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Властивості
        public int Id { get; set; }
        /// <summary>
        /// Ім'я.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Стать.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вага.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Ріст.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Розрахунок віку.
        /// </summary>
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;

                if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
                {
                    age--;
                }

                return age;
            }
        }
        #endregion

        public User() { }

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

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}