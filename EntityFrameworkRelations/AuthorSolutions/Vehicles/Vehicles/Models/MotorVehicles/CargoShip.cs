namespace Vehicles.Models.MotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CargoShips")]
    class CargoShip : Ship
    {
        public int MaxLoadKilograms { get; set; }
    }
}
