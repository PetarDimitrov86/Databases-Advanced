namespace _14_VehiclesDb.Models.ChildClasses
{
    using BaseClasses;
    using System.Collections.Generic;

    public class Train : MotorVehicle
    {
        public Train()
        {
            Carriages = new HashSet<Carriage>();
        }

        public int NumberOfCarriages { get; set; }

        public virtual Locomotive Locomotive { get; set; }

        public virtual ICollection<Carriage> Carriages { get; set; }
    }
}