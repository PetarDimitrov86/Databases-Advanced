namespace _14_VehiclesDb.Models.BaseClasses
{
    using ChildClasses;

    public abstract class Carriage
    {
        public int Id { get; set; }

        public int PassengersSeatCapacity { get; set; }

        public Train Train { get; set; }
    }
}