namespace Vehicles.Models.MotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Locomotives")]
    public class Locomotive : MotorVehicle
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public virtual Train Train { get; set; }
    }
}
