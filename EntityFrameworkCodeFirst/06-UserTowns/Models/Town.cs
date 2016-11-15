using System.ComponentModel.DataAnnotations;

namespace _02_CreateUser.Models
{
    public class Town
    {
        [Key]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [MinLength(3), MaxLength(50)]
        public string Country { get; set; }
    }
}