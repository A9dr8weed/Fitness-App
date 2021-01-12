using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Прийом їжі.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }
        public Dictionary<Food, double> Foods { get; }
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Ім'я не може бути null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            Food product = Foods.Keys.FirstOrDefault(x => x.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}