namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum RoomTypes
    {
        Small, Medium, Large
    }

    public class RoomType
    {
        [Key]
        public RoomTypes Type { get; set; }
                       
        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
