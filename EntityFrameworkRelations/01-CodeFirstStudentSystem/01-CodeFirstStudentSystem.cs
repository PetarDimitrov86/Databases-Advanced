using System;
using _01_CodeFirstStudentSystem.Enums;
using _01_CodeFirstStudentSystem.Models;

namespace _01_CodeFirstStudentSystem
{
    class CodeFirstStudentSystem
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();
            context.Students.Add(new Student
            {
                Name = "Petar",
                RegistrationDate = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}