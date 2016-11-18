namespace UsersDatabase.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserAlbum
    {
        [Key, Column(Order = 0)]
        public virtual int UserId { get; set; }

        public User User { get; set; }

        [Key, Column(Order = 1)]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }

        [Required]
        public string UserRole { get; set; }
    }
}
