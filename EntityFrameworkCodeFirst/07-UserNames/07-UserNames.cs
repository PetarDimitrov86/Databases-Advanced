using _02_User.Models;
using System;
using System.Data.Entity.Validation;

namespace _02_User
{
    class UsersDb
    {
        static void Main(string[] args)
        {
            UsersContext context = new UsersContext();
            User validUser = new User
            {
                Username = "limpbizkit",
                Password = "Sux1111!!!!",
                Email = "somerandom@email.bg",
                LastTimeLoggedIn = DateTime.Now,
                Age = 10,
                isDeleted = false
            };
            //User shortUsername = new User
            //{
            //    Username = "lim", Password = "Sux1111!!!!", Email = "somerandom@email.bg",
            //    LastTimeLoggedIn = DateTime.Now, Age = 10, isDeleted = false
            //};
            //User longUsername = new User
            //{
            //    Username = "limbizxclsdlfkjdsfkjdskjfhdskjfhkdsjfhkdshfkdshfks", Password = "Sux1111!!!!", Email = "somerandom@email.bg", LastTimeLoggedIn = DateTime.Now,
            //    Age = 10, isDeleted = false
            //};
            //User invalidPassword = new User
            //{
            //    Username = "limbizxclsdlf", Password = "Sux!!!!", Email = "somerandom@email.bg",
            //    LastTimeLoggedIn = DateTime.Now, Age = 10, isDeleted = false
            //};
            //User invalidEmailaddress = new User
            //{
            //    Username = "limbizxclsdlf", Password = "Sux!!11!!", Email = ".somerandom@email.bg",
            //    LastTimeLoggedIn = DateTime.Now, Age = 10, isDeleted = false
            //};
            //User invalidAge = new User
            //{
            //    Username = "limbizxclsdlf", Password = "Sux!!11!!", Email = "somerandom@email.bg",
            //    LastTimeLoggedIn = DateTime.Now, Age = 1000, isDeleted = false
            //};
            try
            {
                context.Users.Add(validUser);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}