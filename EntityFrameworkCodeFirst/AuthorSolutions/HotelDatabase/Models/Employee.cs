namespace HotelDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(50)]      
        public string FirstName { get; set; }


        [Required, MinLength(2), MaxLength(50)]    
        public string LastName { get; set; }

        
        [MinLength(2), MaxLength(100)]
        public string Title { get; set; }


        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
