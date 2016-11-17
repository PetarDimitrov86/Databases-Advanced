namespace Vehicles.Models.NonMotorVehicles
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SleepingCarriages")]
    class SleepingCarriage
    {
        public int BedsCount { get; set; }
    }
}
