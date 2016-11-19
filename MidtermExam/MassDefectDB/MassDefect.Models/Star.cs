namespace MassDefect.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Star
    {
        public Star()
        {
            this.Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}