using _02_User.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;

namespace _02_User
{
    class UsersDb
    {
        static void Main(string[] args)
        {
            string desiredEmailProvider = Console.ReadLine();
            UsersContext context = new UsersContext();
            var result = context.Users.Where(u => u.Email.EndsWith("@" + desiredEmailProvider)).Select(u => new
            {
                UserName = u.Username,
                Email = u.Email
            }).ToList();

            foreach (var user in result)
            {
                Console.WriteLine($"{user.UserName} {user.Email}");
            }
        }
    }
}