namespace _01_CodeFirstStudentSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_01_CodeFirstStudentSystem.StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_01_CodeFirstStudentSystem.StudentsContext";
        }

        protected override void Seed(_01_CodeFirstStudentSystem.StudentsContext context)
        {
        }
    }
}
