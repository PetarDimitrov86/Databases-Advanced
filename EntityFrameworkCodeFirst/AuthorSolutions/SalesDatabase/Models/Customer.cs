namespace SalesDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required, MinLength(3)]
        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
