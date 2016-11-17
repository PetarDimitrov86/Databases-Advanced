namespace FootballBettingModels
{
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
