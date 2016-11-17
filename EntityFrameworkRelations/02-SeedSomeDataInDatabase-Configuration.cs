using _01_CodeFirstStudentSystem.Enums;

namespace _01_CodeFirstStudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_01_CodeFirstStudentSystem.StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_01_CodeFirstStudentSystem.StudentsContext";
        }

        protected override void Seed(StudentsContext context)
        {
            context.Students.AddOrUpdate(s => s.Name, new Student
            {
                Name = "Pesho",
                PhoneNumber = "214125123",
                RegistrationDate = DateTime.Now
            }, 
            new Student
            {
                Name = "Gosho",
                PhoneNumber = "3523512",
                RegistrationDate = DateTime.Today
            },
            new Student
            {
                Name = "Lidka",
                PhoneNumber = "9941241",
                RegistrationDate = DateTime.Now
            });

            context.Courses.AddOrUpdate(c => c.Name, new Course
            {
                Name = "Mathematics",
                Description = "With Computer Science",
                StartDate = DateTime.ParseExact("2011-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2013-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Price = 10010.11m
            }, new Course
            {
                Name = "Physics",
                Description = "Learning from Mythbusters videos",
                StartDate = DateTime.ParseExact("2012-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2015-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Price = 10010.11m
            }, new Course
            {
                Name = "History",
                Description = "With Kovacheva",
                StartDate = DateTime.ParseExact("2011-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2013-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Price = 10010.11m
            });


            context.Homeworks.AddOrUpdate(h => h.Content, new Homework
            {
                Content = "MathHomework"
            }, new Homework
            {
                Content = "Petar'sPhysicsHomework"
            }, new Homework
            {
                Content = "HistoryHW"
            });

            context.Resources.AddOrUpdate(r => r.Name, 
                new Resource
            {
                Name = "Wikipedia",
                TypeOfResource = ResourceTypes.Document,
                URL = "www.wikipedia.org"
            },
                new Resource
            {
                Name = "YouTube",
                TypeOfResource = ResourceTypes.Video,
                URL = "www.youtube.com"
            }, 
                new Resource
            {
                Name = "Scenereleases",
                TypeOfResource = ResourceTypes.Other,
                URL = "www.thepiratebay.org"
            });
        }
    }
}