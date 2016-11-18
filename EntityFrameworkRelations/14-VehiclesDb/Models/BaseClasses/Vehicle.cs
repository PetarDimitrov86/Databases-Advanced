namespace _14_VehiclesDb.Models
{
    public abstract class Vehicle
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public decimal MaxSpeed { get; set; }
    }
}