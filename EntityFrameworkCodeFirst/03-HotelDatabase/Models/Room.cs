using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class Room
    {
        [Key]
        public string RoomNumber { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public BedType BedType { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public RoomStatus RoomStatus { get; set; }

        public string Notes { get; set; }
    }
}