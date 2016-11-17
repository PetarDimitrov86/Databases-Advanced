namespace BillingPaymentSystem
{
    using System.Data.Entity;
    using BillingPaymentSystem.Models;

    public class TphBillsContext : DbContext
    {
        public TphBillsContext()
            : base("name=TphBillsContext")
        {
        }
        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<BilliingDetail> BilliingDetails { get; set; }
    }
}