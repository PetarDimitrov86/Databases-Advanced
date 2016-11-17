using _12_BillsPaymentSystem.Models;

namespace _12_BillsPaymentSystem
{
    public class Program
    {
        static void Main()
        {
            BillsPaymentSystemContext context = new BillsPaymentSystemContext();
            //context.Users.Add(new User
            //{
            //    FirstName = "Petar",
            //    LastName = "Dimitrov",
            //    Email = "lbmikesmith@gmail.com",
            //    Password = "randompasswordisbestpassword"
            //});

            context.BillingDetails.Add(new BillingDetail
            {
               // Id = 1,
                Number = "JustStandardBillingDetail",
                Owner = "SomeDouche"
            });

            context.BillingDetails.Add(new BankAccount
            {
                //Id = 2,
                BankName = "Deutsche Bank",
                Number = "12345678910",
                Owner = "DoucheMacBaginson",
                SWIFTCode = "691123420ACZ"
            });

            context.BillingDetails.Add(new CreditCard
            {
                //Id = 3,
                CardType = "VISA",
                ExpirationMonth = "July",
                ExpirationYear = "2018",
                Number = "125612354",
                Owner = "Andy Samberg"
            });

            context.SaveChanges();
        }
    }
}