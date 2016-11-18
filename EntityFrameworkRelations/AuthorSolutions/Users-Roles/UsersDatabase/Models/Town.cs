namespace UsersDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public Town()
        {
            this.LivingUsers = new HashSet<User>();
            this.BornUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CountryName { get; set; }

        public virtual ICollection<User> LivingUsers { get; set; }

        public virtual ICollection<User> BornUsers { get; set; }
    }
}
