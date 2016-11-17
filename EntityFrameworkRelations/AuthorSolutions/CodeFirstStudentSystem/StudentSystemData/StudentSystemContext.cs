namespace StudentSystemData
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CodeFirstStudentSystem.Models;
    using StudentSystemModels;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Licence> Licences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Course>(student => student.Courses)
                .WithMany(course => course.Students)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("StudentId");
                    configuration.MapRightKey("CourseId");
                    configuration.ToTable("StudentCourses");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}