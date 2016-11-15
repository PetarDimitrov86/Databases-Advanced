namespace SalesDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public StoreLocation StoreLocation { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}
