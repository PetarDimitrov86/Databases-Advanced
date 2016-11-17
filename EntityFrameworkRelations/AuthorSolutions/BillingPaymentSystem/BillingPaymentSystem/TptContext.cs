namespace BillingPaymentSystem
{
    using System.Data.Entity;
    using Models;

    public class TptContext : DbContext
    {
        public TptContext()
            : base("name=TptBillsContext")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<BilliingDetail> BilliingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");

            base.OnModelCreating(modelBuilder);
        }
    }
}