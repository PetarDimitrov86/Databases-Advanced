namespace CreateGringots.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Deposit
    {   
        [MaxLength(20)]
        public string Group { get; set; }
        
        public DateTime StartDate { get; set; }

        public decimal Amount { get; set; }

        public decimal Interest { get; set; }

        public decimal Charge { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsDepositeGroup { get; set; }
    }
}
