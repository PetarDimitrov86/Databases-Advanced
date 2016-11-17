namespace Vehicles.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicles")]
    public abstract class Vehicle
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int MaxSpeed { get; set; }
    }
}
