namespace CodeFirstStudentSystem.Models
{
    using System.Collections.Generic;
    using StudentSystemModels;

    public enum ResourceType
    {
        Video, Presentation, Document, Other
    }

    public class Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ResourceType Type { get; set; }

        public string Url { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Licence> Licences { get; set; }
    }
}
