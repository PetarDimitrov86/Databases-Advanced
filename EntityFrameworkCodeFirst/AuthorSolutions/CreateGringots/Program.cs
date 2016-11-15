using System;

namespace CreateGringots
{
    using System.Data.Entity.Validation;
    using CreateGringots.Models;

    class Program
    {
        static void Main()
        {
            GringottsContext gringotts = new GringottsContext();

            try
            {
                WizardDeposit deposit = new WizardDeposit
                {
                    Wizzard = new Wizzard()
                    {
                        Age = 150,
                        FirstName = "Peter",
                        LastName = "Griphin"
                    },
                    Deposit = new Deposit()
                    {
                        Amount = 100,
                        Charge = 2.3m,
                        ExpirationDate = new DateTime(1992, 02, 10),
                        Group = "Orks",
                        Interest = 34.3m,
                        StartDate = new DateTime(1989, 10, 29),
                        IsDepositeGroup = true
                    },
                    MagicWandInfo = new MagicWand()
                    {
                        Creator = "Peter Petrelli",
                        Size = 20
                    }
                };
                gringotts.WizardDeposits.Add(deposit);
                gringotts.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult dbEntityValidationResult in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError dbValidationError in dbEntityValidationResult.ValidationErrors)
                    {
                        Console.WriteLine(dbValidationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
