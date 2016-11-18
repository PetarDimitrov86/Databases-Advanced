namespace _14_VehiclesDb.Models.ChildClasses
{
    using BaseClasses;

    public class Car : MotorVehicle
    {
        public int NumberOfDoors { get; set; }

        public bool IsInsured { get; set; }
    }
}