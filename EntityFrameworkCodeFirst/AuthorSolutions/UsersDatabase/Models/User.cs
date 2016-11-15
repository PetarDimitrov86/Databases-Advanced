namespace UsersDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.IO;
    using UsersDatabase.Attributes;

    public partial class User
    {
        private string password;

        private string email;

        [Key, Column]
        public int Id { get; set; }


        [Required, MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, Password(4, 20, ShouldContainLowercase = true, ShouldContainUppercase = true, ShouldContainSpecialSymbol = true, ShouldContainDigit = false)]
        // [MinLength(6), MaxLength(50)]
        public string Password
        {
            get { return this.password; }
            set
            {
                //if (!this.CheckIfLowLetterIsContained(value)
                //    || !this.CheckIfUpperLetterIsContained(value)
                //    || !this.CheckIfDigitIsContained(value)
                //    || !this.CheckIfSpecialSymbolsIsContained(value))
                //{
                //    throw new ArgumentException("The password must contain at least one lower and one capital letter, one digit and one special symbol.");
                //}

                this.password = value;
            }
        }

        [Required, Email]
        public string Email
        {
            get { return this.email; }
            set
            {
                //if (!EmailIsValid(value))
                //{
                //    throw new ArgumentException("Emails is not in the valid format.");
                //}  
                this.email = value;
            }
        }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public Town BornTown { get; set; }

        public Town CurrentlyLivingTown { get; set; }
    }
}
