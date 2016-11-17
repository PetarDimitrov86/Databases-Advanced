namespace Vehicles.Models.NonMotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bike")]
    public class Bike
    {
        public int ShiftCount { get; set; }

        public string Color { get; set; }
    }
}
