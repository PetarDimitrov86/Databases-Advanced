namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Models;

    public class ShareAlbumCommand : Command
    {
        public ShareAlbumCommand(string[] data) : base(data)
        {
        }

        //ShareAlbum <albumId> <username> <permission>
        //For example:
        //ShareAlbum 4 dragon321 Owner
        //ShareAlbum 4 dragon11 Viewer
        public override string Execute()
        {
            int albumId = int.Parse(Data[1]);
            string desiredUsername = Data[2];
            Role role = (Role) Enum.Parse(typeof(Role), Data[3], true);

            Album albumToChange = this.unit.Albums.FirstOrDefaultWhere(a => a.Id == albumId);
            User userToChange = this.unit.Users.FirstOrDefaultWhere(u => u.Username == desiredUsername);

            AlbumRole albumRole = new AlbumRole
            {
                Album = albumToChange,
                Role = role,
                User = userToChange
            };

            this.unit.AlbumRoles.Add(albumRole);

            return $"User {desiredUsername} is now an {Data[3]} of the album {albumToChange.Name}";
        }
    }
}
