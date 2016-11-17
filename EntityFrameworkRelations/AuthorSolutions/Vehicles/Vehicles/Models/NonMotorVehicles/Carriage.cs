namespace Vehicles.Models.NonMotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Vehicles.Models.MotorVehicles;

    [Table("Carriages")]
    public abstract class Carriage : NonMotorVehicle
    {
        public int PassengersSeats { get; set; }

        public virtual Train Train { get; set; }
    }
}
