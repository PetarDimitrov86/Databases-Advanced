namespace SalesDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StoreLocation
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string LocationName { get; set; }

        public ICollection<Sale> Sales { get; set; }


    }
}
