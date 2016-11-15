namespace UsersDatabase.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.IO;

    public partial class User
    {

        [NotMapped]
        public Image ProfileImage
        {
            get
            {
                var stream = new MemoryStream(this.ProfilePicture.Length);
                foreach (var chunk in this.ProfilePicture)
                {
                    stream.WriteByte(chunk);
                }

                return Image.FromStream(stream);
            }
        }


        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
