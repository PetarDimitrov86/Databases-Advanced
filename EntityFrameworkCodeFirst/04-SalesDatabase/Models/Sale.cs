using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04_SalesDatabase.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int StoreLocationId { get; set; }

        [ForeignKey("StoreLocationId")]
        public StoreLocation StoreLocation { get; set; }

        public DateTime Date { get; set; }
    }
}