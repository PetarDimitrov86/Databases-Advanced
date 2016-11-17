namespace CodeFirstStudentSystem.Client
{
    using System;
    using System.Data.Entity.SqlServer;
    using System.Data.SqlTypes;
    using System.Linq;
    using CodeFirstStudentSystem.Models;
    using StudentSystemData;

    class Program
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();

            AllStudentsAndHomeworkSubmissions(context);

            Console.WriteLine();

            AllCoursesWithCorrespondingResources(context);

            Console.WriteLine();

            AllCoursesWithMoreThan5Resources(context);

            Console.WriteLine();

            AllCoursesActiveOnGivenDate(context, DateTime.Today);

            Console.WriteLine();

            AllStudentsWithCoursesInfo(context);
        }

        private static void AllStudentsWithCoursesInfo(StudentSystemContext context)
        {
            var students = context.Students
                .OrderByDescending(student => student.Courses.Sum(course => course.Price))
                .ThenByDescending(student => student.Courses.Count)
                .ThenBy(student => student.Name);

            foreach (Student student in students)
            {
                if (student.Courses.Count != 0)
                {
                    Console.WriteLine(
                        $"{student.Name} - {student.Courses.Count} - {student.Courses.Sum(course => course.Price)} - {student.Courses.Average(course => course.Price)}");
                }
            }
        }

        private static void AllCoursesActiveOnGivenDate(StudentSystemContext context, DateTime activeDate)
        {
            var courses = context.Courses
                .Where(course => course.StartDate <= activeDate && course.EndDate >= activeDate)
                .OrderBy(course => course.Students.Count)
                .Select(course => new
                {
                    course.Name,
                    course.StartDate,
                    course.EndDate,
                    Duration = SqlFunctions.DateDiff("day", course.StartDate, course.EndDate),
                    StudentsCount = course.Students.Count
                });

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} {course.StartDate} {course.EndDate} {course.Duration} - {course.StudentsCount}");
            }
        }

        private static void AllCoursesWithMoreThan5Resources(StudentSystemContext context)
        {
            var courses =
                context.Courses.Where(course => course.Resources.Count > 5)
                    .OrderByDescending(course => course.Resources.Count)
                    .ThenByDescending(course => course.StartDate);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name} - {course.Resources.Count}");
            }
        }

        private static void AllCoursesWithCorrespondingResources(StudentSystemContext context)
        {
            var courses = context.Courses.OrderBy(course => course.StartDate).ThenByDescending(course => course.EndDate);
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Name} {course.Description}");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"--{resource.Name} {resource.Type} {resource.Url}");
                }
            }
        }

        private static void AllStudentsAndHomeworkSubmissions(StudentSystemContext context)
        {
            var students = context.Students;

            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                foreach (var homeworkSubmission in student.Homeworks)
                {
                    Console.WriteLine($"--{homeworkSubmission.Content} - {homeworkSubmission.ContentType}");
                }
            }
        }
    }
}
