namespace _12_BillsPaymentSystem
{
    using System.Data.Entity;
    using Models;

    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext()
            : base("name=BillsPaymentSystemContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table Per Hierarchy (TPH) - Default Strategy, Changing the default Discriminator Column Name, and default Discriminator Value

            //modelBuilder.Entity<BillingDetail>()
            //    .Map<BankAccount>(m =>
            //        m.Requires("DiscrColumnForBankAcc")
            //            .HasValue("DefaultBankDiscrAccValue")
            //    )
            //    .Map<CreditCard>(m =>
            //        m.Requires("DiscrColumnForCreditCard")
            //            .HasValue("DefaultCreditCardDiscrValue"));

            //Table Per Type (TPT) Seperate table for each of the children classes
            //Another way to do it is to add the [Table("TableName")] Attribute above each of the children classes

            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");

            //Table Per Concrete Type (TPC)
            //Each of the class Tables will have all of the columns from the Parents Class

            //modelBuilder.Entity<BankAccount>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("BankAccounts");
            //});
            //modelBuilder.Entity<CreditCard>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("CreditCards");
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
