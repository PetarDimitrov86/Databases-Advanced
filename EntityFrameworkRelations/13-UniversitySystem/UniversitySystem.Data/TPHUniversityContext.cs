namespace UniversitySystem.Data
{
    using System.Data.Entity;
    using Models;

    public class TPHUniversityContext : DbContext
    {
        public TPHUniversityContext()
            : base("name=UniversitySystemContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(sc =>
                {
                    sc.MapLeftKey("StudentId");
                    sc.MapRightKey("CourseId");
                    sc.ToTable("StudentsCourses");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}