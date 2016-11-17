using System;
using _07_Tags.Models;

namespace _07_Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext context = new UserContext();
            User validUser = new User
            {
                Username = "limpbizkit",
                Password = "Sux1111!!!!",
                Email = "somerandom@email.bg",
                LastTimeLoggedIn = DateTime.Now,
                Age = 10,
                isDeleted = false
            };
            context.Users.Add(validUser);
            context.SaveChanges();
        }
    }
}