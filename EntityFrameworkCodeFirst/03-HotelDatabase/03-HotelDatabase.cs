using _03_HotelDatabase.Models;

namespace _03_HotelDatabase
{
    public class HotelDatabase
    {
        static void Main(string[] args)
        {
            HotelContext context = new HotelContext();

            //Employee employee = new Employee
            //{
            //    Id = 1,
            //    FirstName = "Petar",
            //    LastName = "Dimitrov",
            //    Title = "Mr.",
            //    Notes = "Just mediocre"
            //};
            //context.Employees.Add(employee);

            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "Nikolay",
                LastName = "Petkov",
                AccountNumber = "1234567891",
                PhoneNumber = "00359885428144",
                Notes = "Straight Outta Compton"
            };

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}