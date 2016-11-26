namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Collections.Generic;

    public class CreateAlbumCommand : Command
    {

        public CreateAlbumCommand(string[] data) : base(data)
        {
        }

        //CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override string Execute()
        {
            string username = Data[1];
            string albumTitle = Data[2];
            Color color = (Color) Enum.Parse(typeof(Color), Data[3], true);
            User albumsUser = this.unit.Users.FirstOrDefaultWhere(user => user.Username == username);

            List<Tag> tagsToAdd = new List<Tag>();

            for (int i = 4; i < Data.Length; i++)
            {
                string tagName = Data[i].ValidateOrTransform();
                Tag newTag = new Tag {Name = tagName};
                tagsToAdd.Add(newTag);
            }

            Album albumToAdd = new Album
            {
                BackgroundColor = color,
                Name = albumTitle,
                Tags = tagsToAdd
            };

            this.unit.AlbumRoles.Add(new AlbumRole
            {
                Album = albumToAdd,
                User = albumsUser,
                Role = Role.Owner
            });

            return  $"Album called {albumTitle} was created with hashtags {string.Join(", ", tagsToAdd)}. It's background colour is {Data[3]} and it's owner is {username}";
        }
    }
}