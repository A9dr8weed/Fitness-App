using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Білки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жири.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Вуглеводи.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калорії за 100 грам продукта.
        /// </summary>
        public double Callories { get; set; }

        public Food() { }

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