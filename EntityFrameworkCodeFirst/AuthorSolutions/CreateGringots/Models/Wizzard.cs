namespace CreateGringots.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Wizzard
    {   
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
