namespace Photography.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CustomAttributes;

    public class Photographer
    {
        public Photographer()
        {
            this.Lenses = new HashSet<Lens>();
            this.Accessories = new HashSet<Accessory>();
            this.ParticipantWorkshops = new HashSet<Workshop>();
            this.TrainerWorkshops = new HashSet<Workshop>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [PhoneNumberValidation]
        public string Phone { get; set; }
        
        [Required]
        public virtual Camera PrimaryCamera { get; set; }
        
        [Required]
        public virtual Camera SecondaryCamera { get; set; }

        public virtual ICollection<Lens> Lenses { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Workshop> ParticipantWorkshops { get; set; }

        public virtual ICollection<Workshop> TrainerWorkshops { get; set; }
    }
}