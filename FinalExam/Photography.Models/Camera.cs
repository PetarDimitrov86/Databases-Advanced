namespace Photography.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Camera
    {
        public Camera()
        {
            this.PrimaryCameraOwners = new HashSet<Photographer>();
            this.SecondaryCameraOwners = new HashSet<Photographer>();
        }

        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public bool? IsFullFrame { get; set; }

        [Range(100, Int32.MaxValue), Required]
        public int MinISO { get; set; }

        public int? MaxISO { get; set; }

        [InverseProperty("PrimaryCamera")]
        public virtual ICollection<Photographer> PrimaryCameraOwners { get; set; }

        [InverseProperty("SecondaryCamera")]
        public virtual ICollection<Photographer> SecondaryCameraOwners { get; set; }
    }
}