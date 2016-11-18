namespace UniversitySystem.Data
{
    using System.Data.Entity;
    using Models;

    public class TPTUniversityContext : DbContext
    {

        public TPTUniversityContext()
            : base("name=TPTUniversityContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");

            base.OnModelCreating(modelBuilder);
        }
    }
}