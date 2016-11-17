namespace BillingPaymentSystem
{
    using System.Data.Entity;
    using BillingPaymentSystem.Models;

    public class TpcBillsContext : DbContext
    {
        public TpcBillsContext()
            : base("name=TpcBillsContext")
        {
        }
        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<BilliingDetail> BilliingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BilliingDetail>();

            modelBuilder.Entity<BankAccount>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("BankAccounts");
            });

            modelBuilder.Entity<CreditCard>().Map(configuration =>
            {
                configuration.MapInheritedProperties();
                configuration.ToTable("CreditCards");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}