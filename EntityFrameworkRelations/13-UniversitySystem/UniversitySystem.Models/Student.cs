namespace UniversitySystem.Models
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public decimal AverageGrade { get; set; }

        public decimal Attendance { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}