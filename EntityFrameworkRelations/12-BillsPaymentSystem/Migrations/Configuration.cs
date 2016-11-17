namespace _12_BillsPaymentSystem.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BillsPaymentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "_12_BillsPaymentSystem.BillsPaymentSystemContext";
        }

        protected override void Seed(BillsPaymentSystemContext context)
        {
        }
    }
}