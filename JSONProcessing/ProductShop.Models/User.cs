namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class User
    {
        public User()
        {
            this.ProductsBought = new HashSet<Product>();
            this.ProductsSold = new HashSet<Product>();
            this.Friends = new HashSet<User>();
        }

        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [MinLength(3)]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Friends { get; set; }

        [JsonIgnore]
        [InverseProperty("Seller")]
        public virtual ICollection<Product> ProductsSold { get; set; }

        [JsonIgnore]
        [InverseProperty("Buyer")]
        public virtual ICollection<Product> ProductsBought { get; set; }
    }
}