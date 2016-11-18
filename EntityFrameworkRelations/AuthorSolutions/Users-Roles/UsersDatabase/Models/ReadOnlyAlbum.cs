namespace UsersDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReadOnlyAlbum
    {

        public ReadOnlyAlbum(Album album)
        {
            this.UserAlbums = (IReadOnlyCollection<UserAlbum>)album.UserAlbums;
            this.BackGroundColor = album.BackGroundColor;
            this.Id = album.Id;
            this.IsPublic = album.IsPublic;
            this.Name = album.Name;
            this.Pictures = (IReadOnlyCollection<Picture>)album.Pictures;
            this.Tags = (IReadOnlyCollection<Tag>)album.Tags;
        }

        public int Id { get; }

        [Required]
        public string Name { get; }

        public string BackGroundColor { get; }

        public bool IsPublic { get; }

        public virtual IReadOnlyCollection<Picture> Pictures { get; }

        public virtual IReadOnlyCollection<Tag> Tags { get;  }

        public virtual IReadOnlyCollection<UserAlbum> UserAlbums { get; }
    }
}
