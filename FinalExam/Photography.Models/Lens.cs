namespace Photography.Models
{
    public class Lens
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public int? FocalLength { get; set; }

        public decimal? MaxAperture { get; set; }

        public string CompatibleWith { get; set; }

        public virtual Photographer Photographer { get; set; }
    }
}