namespace SalesDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }                               
}
