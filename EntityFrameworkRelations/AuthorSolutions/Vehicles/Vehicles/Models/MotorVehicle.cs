namespace Vehicles.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MotorVehicles")]
    public abstract class MotorVehicle : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public string EngineType { get; set; }

        public int TankCapacity { get; set; }
    }
}
