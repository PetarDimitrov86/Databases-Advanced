using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _04_SalesDatabase.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            SalesInStore = new HashSet<Sale>();
        }

        [Key]
        public int StoreLocationId { get; set; }

        [MinLength(3), MaxLength(70)]
        [Required]
        public string LocationName { get; set; }

        public ICollection<Sale> SalesInStore { get; set; }
    }
}