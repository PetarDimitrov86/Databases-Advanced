namespace ProductShop.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Products= new HashSet<Product>();
        }
        
        public int Id { get; set; }

        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}