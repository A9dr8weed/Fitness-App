using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class DatabaseSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (FitnessContext db = new FitnessContext())
            {
                return db.Set<T>().Where(_ => true).ToList();
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (FitnessContext db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}