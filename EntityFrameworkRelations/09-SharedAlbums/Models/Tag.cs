﻿using System.Collections.Generic;
using _07_Tags.Validations;

namespace _07_Tags.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        
        [TagValidation]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}