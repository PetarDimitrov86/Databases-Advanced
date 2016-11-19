namespace MassDefect.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class SolarSystem
    {
        public SolarSystem()
        {
            this.Planets = new HashSet<Planet>();
            this.Stars = new HashSet<Star>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
    }
}