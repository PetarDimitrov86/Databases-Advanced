namespace _14_VehiclesDb.Models.BaseClasses
{
    public abstract class Ship : MotorVehicle
    {
        public string Nationality { get; set; }

        public string CaptainName { get; set; }

        public int SizeOfShipCrew { get; set; }
    }
}