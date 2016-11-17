namespace _02_User.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string PathToFile { get; set; }

        public virtual Album Album { get; set; }
    }
}