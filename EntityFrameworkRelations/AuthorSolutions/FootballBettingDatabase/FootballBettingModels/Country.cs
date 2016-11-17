namespace FootballBettingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.Continent = new HashSet<Continent>();
            this.Towns = new HashSet<Town>();
        }

        [Key]
        [MaxLength(3)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Continent> Continent { get; set; }

        public ICollection<Town> Towns { get; set; }

    }
}
