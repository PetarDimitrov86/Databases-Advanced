namespace Vehicles.Models.MotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Planes")]
    class Plane : MotorVehicle
    {
        public string AirlineOwner { get; set; }

        public string Color { get; set; }

        public int PassengersCapacity { get; set; }
    }
}
