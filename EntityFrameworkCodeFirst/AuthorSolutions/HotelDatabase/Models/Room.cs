namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public BedType BedType { get; set; }
        
        public decimal Rate { get; set; }

        [Required]
        public RoomStatus Status { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
