using FitnessApp.BL.Model;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User User;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            Activity act = Activities.SingleOrDefault(x => x.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                Exercise exercise = new Exercise(begin, end, activity, User);
                Exercises.Add(exercise);
            }
            else
            {
                Exercise exercise = new Exercise(begin, end, act, User);
                Exercises.Add(exercise);
            }

            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}