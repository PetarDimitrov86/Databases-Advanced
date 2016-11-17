namespace Vehicles.Models.MotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ships")]
    abstract class Ship : MotorVehicle
    {
        public string Nationality { get; set; }

        public string CaptainName { get; set; }

        public int SizeOfShipCrew { get; set; }
    }
}
