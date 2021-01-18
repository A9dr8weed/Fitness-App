using System.Data.Entity.Migrations;

namespace FitnessApp.BL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FitnessApp.BL.Controller.FitnessContext";
        }

        protected override void Seed(Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
