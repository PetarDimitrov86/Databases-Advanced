namespace Vehicles.Models.NonMotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PassengerCarriages")]
    class PassengerCarriage : Carriage
    {
        public int StandingPassengesCapacity { get; set; }
    }
}
