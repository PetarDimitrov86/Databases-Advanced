namespace Vehicles.Models.MotorVehicles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Vehicles.Models.NonMotorVehicles;

    [Table("Trains")]
    public class Train : MotorVehicle
    {
        public Train()
        {
            this.Carriages = new HashSet<Carriage>();
        }

        public virtual Locomotive Locomotive { get; set; }

        public int NumberOfCarriages { get; set; }

        public virtual ICollection<Carriage> Carriages { get; set; }
    }
}
