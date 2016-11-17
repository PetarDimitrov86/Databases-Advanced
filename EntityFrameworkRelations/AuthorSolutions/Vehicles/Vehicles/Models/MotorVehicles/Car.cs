namespace Vehicles.Models.MotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cars")]
    class Car : MotorVehicle
    {
        public int NumberOfDoors { get; set; }

        public string InsuranceInfo { get; set; }
    }
}
