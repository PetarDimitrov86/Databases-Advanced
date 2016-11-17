namespace CodeFirstStudentSystem.Models
{
    using System;

    public enum ContentType
    {
        Application, Pdf, Zip
    }


    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
