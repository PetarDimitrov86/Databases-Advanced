namespace Vehicles.Models.NonMotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RestaurantCarriages")]
    class RestaurantCarriage
    {
        public int TableCount { get; set; }
    }
}
