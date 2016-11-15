using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [StringLength(14)]
        public string PhoneNumber { get; set; }

        [MinLength(3), MaxLength(50)]
        public string EmergencyName { get; set; }

        [Phone]
        [StringLength(14)]
        public string EmergencyNumber { get; set; }

        [StringLength(10000)]
        public string Notes { get; set; }
    }
}