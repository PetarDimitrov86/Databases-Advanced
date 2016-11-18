namespace UniversitySystem.Client
{
    using Data;
    using Models;
    using System.Linq;

    public class UniversitySystemMain
    {
        static void Main()
        {
            TPHUniversityContext context = new TPHUniversityContext();
            //TPTUniversityContext context = new TPTUniversityContext();

            Teacher firstTeacher = new Teacher
            {
                Email = "teacher1@gmail.com",
                FirstName = "TeacherNumber",
                LastName = "One",
                PhoneNumber = "12451324",
                SalaryPerHour = 4.5m
            };

            Teacher secondTeacher = new Teacher
            {
                Email = "teacher2@gmail.com",
                FirstName = "AnotherTeacher",
                LastName = "Two",
                PhoneNumber = "756854",
                SalaryPerHour = 6.3m
            };

            Teacher thirdTeacher = new Teacher
            {
                Email = "teacher3@gmail.com",
                FirstName = "YetAnotherTeacher",
                LastName = "Three",
                PhoneNumber = "867976967",
                SalaryPerHour = 61.1m
            };

            Student firstStudent = new Student
            {
                Attendance = 1.3m,
                AverageGrade = 4.5m,
                FirstName = "Gosho",
                LastName = "Goshkov",
                PhoneNumber = "3521551234"
            };

            Student secondStudent = new Student
            {
                Attendance = 2.6m,
                AverageGrade = 3.2m,
                FirstName = "Petar",
                LastName = "Petrov",
                PhoneNumber = "5124123"
            };

            Student thirdStudent = new Student
            {
                Attendance = 5.6m,
                AverageGrade = 5.2m,
                FirstName = "Nikolay",
                LastName = "Petkov",
                PhoneNumber = "5121424123"
            };

            Course firstCourse = new Course
            {
                Credits = 10.5m,
                Description = "JustYourAverageCourse",
            };

            Course secondCourse = new Course
            {
                Credits = 4.6m,
                Description = "Mathematics",
            };

            Course thirdCourse = new Course
            {
                Credits = 14.32m,
                Description = "History",
            };

            context.People.Add(firstStudent);
            context.People.Add(secondStudent);
            context.People.Add(thirdStudent);
            context.People.Add(firstTeacher);
            context.People.Add(secondTeacher);
            context.People.Add(thirdTeacher);
            context.Courses.Add(firstCourse);
            context.Courses.Add(secondCourse);
            context.Courses.Add(thirdCourse);

            context.SaveChanges();

            context.People.OfType<Teacher>().First(t => t.FirstName == "TeacherNumber").Courses.Add(firstCourse);
            context.People.OfType<Teacher>().First(t => t.FirstName == "AnotherTeacher").Courses.Add(secondCourse);
            context.People.OfType<Teacher>().First(t => t.FirstName == "YetAnotherTeacher").Courses.Add(thirdCourse);

            context.SaveChanges();

            context.Courses.First(c => c.Description == "JustYourAverageCourse").Teacher = firstTeacher;
            context.Courses.First(c => c.Description == "Mathematics").Teacher = secondTeacher;
            context.Courses.First(c => c.Description == "History").Teacher = thirdTeacher;

            context.People.OfType<Student>().First(s=> s.FirstName == "Gosho").Courses.Add(firstCourse);
            context.People.OfType<Student>().First(s => s.FirstName == "Gosho").Courses.Add(secondCourse);
            context.People.OfType<Student>().First(s => s.FirstName == "Petar").Courses.Add(secondCourse);
            context.People.OfType<Student>().First(s => s.FirstName == "Petar").Courses.Add(thirdCourse);
            context.People.OfType<Student>().First(s => s.FirstName == "Nikolay").Courses.Add(thirdCourse);
            context.People.OfType<Student>().First(s => s.FirstName == "Nikolay").Courses.Add(firstCourse);

            context.SaveChanges();
        }
    }
}