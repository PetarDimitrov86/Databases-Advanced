namespace FootballBettingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Player
    {
        public Player()
        {
            this.PlayerStatisticses = new HashSet<PlayerStatistics>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public Team Team { get; set; }

        public Position Position { get; set; }

        public bool IsCurrentlyInjured { get; set; }

        public ICollection<PlayerStatistics> PlayerStatisticses { get; set; }
    }
}
