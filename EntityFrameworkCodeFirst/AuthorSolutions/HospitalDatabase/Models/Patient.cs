namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }
                
        [Required]
        public string Email { get; set; }


        public DateTime DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        public bool HasMedicalInsurance { get; set; }

        public ICollection<Visitation> Type { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<Medicament> Medicaments { get; set; }    
    }    
}
