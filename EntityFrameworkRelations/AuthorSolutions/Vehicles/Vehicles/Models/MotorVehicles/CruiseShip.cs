namespace Vehicles.Models.MotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CruiseShips")]
    class CruiseShip : Ship
    {
        public int PassengesCapacity { get; set; }
    }
}
