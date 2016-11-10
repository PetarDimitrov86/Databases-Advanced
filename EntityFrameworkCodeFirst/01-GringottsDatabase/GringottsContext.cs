namespace _01_GringottsDatabase
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }
        public virtual IDbSet<WizzardDeposit> WizzardDeposits { get; set; }        
    }
}