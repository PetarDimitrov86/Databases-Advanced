using System;
using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class Occupancy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOccupied { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public decimal RateApplied { get; set; }

        [Required]
        public bool PhoneCharge { get; set; }

        public string Notes { get; set; }
    }
}