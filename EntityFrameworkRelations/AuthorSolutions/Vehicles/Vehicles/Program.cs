namespace Vehicles
{
    using System;
    using System.Data.Entity.Validation;

    class Program
    {
        static void Main()
        {
            try
            {
                VehiclesContext context = new VehiclesContext();
                context.Database.Initialize(true);
            }
            catch (DbEntityValidationException ex )
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
