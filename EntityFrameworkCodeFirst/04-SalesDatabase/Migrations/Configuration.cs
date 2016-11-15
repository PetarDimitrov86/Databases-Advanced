namespace _04_SalesDatabase.Migrations
{
    using System.Data.Entity.Migrations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_04_SalesDatabase.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SalesContext context)
        {
            int customerIdToAddNext = context.Customers.Count() + 1;
            List<string> randomNames = new List<string>
            {
                "Bob",
                "Paul",
                "Petar",
                "George",
                "Alexander",
                "Lidiya",
                "Silviya",
                "Daniela",
                "Svetoslav",
                "Deniz",
                "Doncho",
                "Ivo"
            };
            List<string> randomEmails = new List<string>
            {
                "emailnumber1@gmail.com",
                "emailnumber2@gmail.com",
                "emailnumber3@gmail.com",
                "emailnumber4@gmail.com",
                "emailnumber5@gmail.com",
                "emailnumber6@gmail.com",
                "emailnumber7@gmail.com",
                "emailnumber8@gmail.com",
                "emailnumber9@gmail.com",
                "emailnumber10@gmail.com",
            };
            List<string> randomAccountNumbers = new List<string>
            {
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };

            Random random = new Random(DateTime.Now.Millisecond);

            //for (int i = 0; i < 20; i++)
                context.Customers.AddOrUpdate(c => c.Name, new Customer { CustomerId = customerIdToAddNext, Name = randomNames[random.Next(0, 11)], Email = randomEmails[random.Next(0, 9)], CreditCardNumber = randomAccountNumbers[random.Next(0, 8)] });
            context.SaveChanges();
        }
    }
}