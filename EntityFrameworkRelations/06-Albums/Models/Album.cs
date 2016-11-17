using System.Collections.Generic;

namespace _02_User.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColour { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual User User { get; set; }
    }
}