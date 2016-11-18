namespace _14_VehiclesDb.Models.BaseClasses
{
    public abstract class Non_MotorVehicle : Vehicle
    {
        public int ShiftsCount { get; set; }

        public string Colour { get; set; }
    }
}