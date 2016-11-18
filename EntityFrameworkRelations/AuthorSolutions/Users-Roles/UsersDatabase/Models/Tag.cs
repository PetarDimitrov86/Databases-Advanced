namespace UsersDatabase.Models
{
    using Attributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [Required, Tag]
        public string TagLabel { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
