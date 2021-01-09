using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Білки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жири.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Вуглеводи.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калорії за 100 грам продукта.
        /// </summary>
        public double Callories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double callories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}