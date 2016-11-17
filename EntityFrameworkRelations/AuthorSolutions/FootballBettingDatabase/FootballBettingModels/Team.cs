namespace FootballBettingModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Logo { get; set; }

        [Required]
        [MaxLength(3)]
        public string ThreeLetterInitials { get; set; }

        [Required]
        public Color PrimaryKitColor { get; set; }

        [Required]
        public Color SecondaryKitColor { get; set; }

        public Town Town { get; set; }

        public decimal Budget { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
