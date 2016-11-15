namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum BedTypes
    {
        KingSize, Small, Large, Medium
    }

    public class BedType
    {
        [Key]
        public BedTypes Type { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}