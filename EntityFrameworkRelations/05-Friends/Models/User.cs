using _02_User.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02_User.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [PasswordValidation]
        [MinLength(6), MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [EmailValidation]
        public string Email { get; set; }

        [MaxLength(1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int? Age { get; set; }

        public bool isDeleted { get; set; }

        public virtual ICollection<User> Friends { get; set; }
    }
}