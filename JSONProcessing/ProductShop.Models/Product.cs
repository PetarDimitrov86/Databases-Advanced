namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual User Buyer { get; set; }

        [JsonIgnore]
        public virtual User Seller { get; set; }

        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }
    }
}