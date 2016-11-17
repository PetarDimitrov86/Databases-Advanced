using System;
using _01_CodeFirstStudentSystem.Enums;

namespace _01_CodeFirstStudentSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType? ContentType { get; set; }

        public DateTime? SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}