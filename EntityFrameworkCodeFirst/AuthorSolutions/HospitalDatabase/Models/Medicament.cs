namespace HospitalDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}
