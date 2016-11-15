using System;
using System.ComponentModel.DataAnnotations;

namespace _03_HotelDatabase.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime? FirstDateOccupied { get; set; }
        
        public DateTime? LastDateOccupied { get; set; }

        public int TotalDays { get; set; }

        [Required]
        public decimal AmountCharged { get; set; }
        
        [Required]
        public decimal TaxRate { get; set; }

        [Required]
        public decimal TaxAmount { get; set; }

        [Required]
        public decimal PaymentTotalDecimal { get; set; }

        [MaxLength(10000)]
        public string Notes { get; set; }
    }
}