using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CalloriesPerMinute { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public Activity() { }

        public Activity(string name, double calloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Ім'я не може бути пустим або null", nameof(name));
            }

            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }

        public override string ToString() => Name;
    }
}