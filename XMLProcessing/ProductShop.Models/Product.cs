namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public double Price { get; set; }

        public virtual User Buyer { get; set; }

        public virtual User Seller { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}