using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _04_SalesDatabase.Models
{
    public class Customer
    {
        public Customer()
        {
           SalesForCustomer = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [MinLength(3), MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(14)]
        [Required]
        public string CreditCardNumber { get; set; }

        public ICollection<Sale> SalesForCustomer { get; set; }
    }
}