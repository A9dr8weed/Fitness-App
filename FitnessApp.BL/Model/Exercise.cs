using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активність не може бути null", nameof(activity));
            User = user ?? throw new ArgumentNullException("Користувач не можу бути null", nameof(user));
        }
    }
}