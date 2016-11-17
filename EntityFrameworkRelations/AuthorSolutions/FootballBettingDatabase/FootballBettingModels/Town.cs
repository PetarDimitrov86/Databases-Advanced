namespace FootballBettingModels
{
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public int Id { get; set; }
                     
        [Required]
        public string Name { get; set; }

        public Country Country { get; set; }
    }
}
