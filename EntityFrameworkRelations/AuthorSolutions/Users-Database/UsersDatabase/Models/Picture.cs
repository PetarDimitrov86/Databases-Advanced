namespace UsersDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Caption { get; set; }

        public string PathOnFileSystem { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
