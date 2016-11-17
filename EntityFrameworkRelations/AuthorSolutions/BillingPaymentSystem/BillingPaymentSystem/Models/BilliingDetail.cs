namespace BillingPaymentSystem.Models
{
    using System.Security.AccessControl;

    public class BilliingDetail
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public User Owner { get; set; }
    }
}
