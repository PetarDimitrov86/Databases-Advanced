using _01_CodeFirstStudentSystem.Models;
using System.Data.Entity;

namespace _01_CodeFirstStudentSystem
{
    public class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("name=StudentsContext")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Resource> Resources { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
    }
}