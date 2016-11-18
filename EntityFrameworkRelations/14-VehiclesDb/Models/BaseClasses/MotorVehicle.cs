namespace _14_VehiclesDb.Models.BaseClasses
{
    public class MotorVehicle : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public string EngineType { get; set; }

        public decimal TankCapacity { get; set; }
    }
}