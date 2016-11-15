namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum RoomStatuses
    {
        Occupied, Free, BeingCleaned
    }

    public class RoomStatus
    {
        [Key]
        public RoomStatuses Status { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

    }
}
