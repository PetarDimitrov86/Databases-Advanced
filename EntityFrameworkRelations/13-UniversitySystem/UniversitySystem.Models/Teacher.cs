namespace UniversitySystem.Models
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }

        public string Email { get; set; }

        public decimal SalaryPerHour { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}