namespace FootballBettingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Round
    {
        public Round()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
