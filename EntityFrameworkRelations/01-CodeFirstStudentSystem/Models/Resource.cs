using System.ComponentModel.DataAnnotations;
using _01_CodeFirstStudentSystem.Enums;

namespace _01_CodeFirstStudentSystem.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceTypes TypeOfResource { get; set; }

        [Required]
        public string URL { get; set; }

        public virtual Course Course { get; set; }
    }
}