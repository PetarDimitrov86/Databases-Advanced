namespace UsersDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Attributes;

    public partial class User
    {
        private ICollection<UserAlbum> userAlbums;

        public User()
        {
            this.Friends = new HashSet<User>();
            this.userAlbums = new HashSet<UserAlbum>();
        }

        [Key, Column]
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, Password(4, 20, ShouldContainLowercase = true, ShouldContainUppercase = true, ShouldContainSpecialSymbol = true, ShouldContainDigit = false)]
        public string Password { get; set; }

        [Required, Email]
        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        [InverseProperty("BornUsers")]
        public virtual Town BornTown { get; set; }

        [InverseProperty("LivingUsers")]
        public virtual Town CurrentlyLivingTown { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public virtual ICollection<UserAlbum> UserAlbums
        {
            get { return this.userAlbums; }
            set { this.userAlbums = value; }
        }
    }
}
