using System.ComponentModel.DataAnnotations;

namespace _01_CodeFirstStudentSystem.Models
{
    public class License
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}