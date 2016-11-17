namespace StudentSystemData.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using CodeFirstStudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            context.Courses.AddOrUpdate(course => course.Name,
                new Course()
                {
                    Name = "C#",
                    Description = "some sharp",
                    EndDate = new DateTime(2017, 2, 3),
                    Price = 2,
                    Homeworks = new List<Homework>()
                    {
                        new Homework()
                        {
                        Content = "C# homework",
                        ContentType = ContentType.Application,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Name = "Pesho",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                        },
                        new Homework()
                        {
                           Content = "java homework",
                        ContentType = ContentType.Pdf,
                        SubmissionDate = DateTime.Today,
                        Student = new Student()
                        {
                            Name = "Stancho",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                        }
                    },
                    StartDate = DateTime.Today,
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Ivo",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        } ,
                         new Student()
                        {
                            Name = "Reni",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "08869899899"
                        }
                    },
                    Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "rsrc",
                            Type = ResourceType.Document,
                            Url = "usadl"
                        },
                        new Resource()
                        {
                             Name = "redasdas",
                             Type = ResourceType.Document,
                             Url = "fsafasf"
                        }
                    }
                });
        }
    }
}
