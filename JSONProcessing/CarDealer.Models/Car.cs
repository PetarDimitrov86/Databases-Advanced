namespace CarDealer.Models
{
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
            this.Sales = new HashSet<Sale>();
            this.Parts = new HashSet<Part>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}