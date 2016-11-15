namespace UsersDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CountryName { get; set; }
    }
}
