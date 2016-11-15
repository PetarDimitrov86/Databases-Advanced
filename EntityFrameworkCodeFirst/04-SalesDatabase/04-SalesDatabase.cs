using _04_SalesDatabase.Models;

namespace _04_SalesDatabase
{
    public class SalesDatabase
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();

            Customer customer = new Customer
            {
                CustomerId = 1,
                Name = "Petar Dimitrov",
                Email = "lbmikesmith@gmail.com",
                CreditCardNumber = "11112222333344"
            };

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}