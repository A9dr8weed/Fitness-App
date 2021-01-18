﻿using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Стать.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Назва.
        /// </summary>
        public string Name { get; set; }

        public Gender() { }

        /// <summary>
        /// Створити нову стать.
        /// </summary>
        /// <param name="name"> Ім'я статі. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Ім'я статі не можу бути пустим чи null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}