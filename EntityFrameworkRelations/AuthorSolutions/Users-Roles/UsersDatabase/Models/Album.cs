namespace UsersDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.UserAlbums = new HashSet<UserAlbum>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string BackGroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<UserAlbum> UserAlbums { get; set; }
    }
}
