using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [MinLength(2), MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(10000)]
        public string Notes { get; set; }
    }
}