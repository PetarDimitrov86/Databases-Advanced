using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class BedType
    {
        [Key]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [MaxLength(10000)]
        public string Notes { get; set; }
    }
}