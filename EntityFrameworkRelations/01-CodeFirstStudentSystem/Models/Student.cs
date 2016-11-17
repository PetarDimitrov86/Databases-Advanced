using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_CodeFirstStudentSystem.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}