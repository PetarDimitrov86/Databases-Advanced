namespace UsersDatabase.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.IO;

    public partial class User
    {
        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
