namespace _14_VehiclesDb.Models.ChildClasses
{
    using BaseClasses;

    public class Plane : MotorVehicle
    {
        public string AirlineOwner { get; set; }

        public string Color { get; set; }

        public int PassengersCapacity { get; set; }
    }
}