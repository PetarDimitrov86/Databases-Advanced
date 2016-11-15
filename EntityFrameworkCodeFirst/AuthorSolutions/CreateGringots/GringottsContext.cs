namespace CreateGringots
{
    using System.Data.Entity;
    using CreateGringots.Models;

    public class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }

        public DbSet<WizardDeposit> WizardDeposits { get; set; }

    }

}