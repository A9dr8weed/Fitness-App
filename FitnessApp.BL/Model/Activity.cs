using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CalloriesPerMinute { get; set; }

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