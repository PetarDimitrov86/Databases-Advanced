namespace _01_CodeFirstStudentSystem
{
    using System;
    using System.Linq;
    using Enums;
    class CodeFirstStudentSystem
    {
        static void Main(string[] args)
        {
            StudentsContext context = new StudentsContext();

            Console.WriteLine("Lists of students and their homeworks:");
            var studentHomeworks = context.Students.Select(s => new
            {
                StudentName = s.Name,
                StudentHomework = s.Homeworks
            });
            foreach (var studentHomework in studentHomeworks)
            {
                Console.WriteLine(studentHomework.StudentName);
                foreach (var studentHW in studentHomework.StudentHomework)
                {
                    int enumValue = (int) studentHW.ContentType;
                    string stringValue = Enum.GetName(typeof(ContentType), enumValue);
                    Console.WriteLine($"--HW-- {studentHW.Content} - {stringValue}");
                }
            }

            Console.WriteLine("All courses and their resources:");
            var coursesResources = context.Courses.Select(c => new
            {
                CourseName = c.Name,
                CourseDescription = c.Description,
                Resources = c.Resources
            });
            foreach (var coursesResource in coursesResources)
            {
                Console.WriteLine(coursesResource.CourseName + " - " + coursesResource.CourseDescription);
                foreach (var resource in coursesResource.Resources)
                {
                    Console.WriteLine($"--ResourceInfo-- {resource.Name} - {resource.URL}");
                }
            }
            context.SaveChanges();
        }
    }
}