namespace StudentSystemModels
{
    using System.ComponentModel.DataAnnotations;
    using CodeFirstStudentSystem.Models;

    public class Licence
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
