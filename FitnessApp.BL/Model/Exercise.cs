using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активність не може бути null", nameof(activity));
            User = user ?? throw new ArgumentNullException("Користувач не можу бути null", nameof(user));
        }


    }
}