namespace FootballBettingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Continent
    {
        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
