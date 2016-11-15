using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class RoomStatus
    {
        [Key]
        [MinLength(3), MaxLength(20)]
        public string RoomStat { get; set; }

        [MaxLength(10000)]
        public string Notes { get; set; }
    }
}