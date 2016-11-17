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
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string BackGroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
