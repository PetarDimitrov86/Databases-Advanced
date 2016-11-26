namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Models;

    public class ModifyAlbumCommand : Command
    {
        public ModifyAlbumCommand(string[] data) : base(data)
        {
        }

        //ModifyAlbum <albumId> <property> <new value>
        //For example
        //ModifyAlbum 4 Name <new name>
        //ModifyAlbum 4 BackgroundColor <new color>
        //ModifyAlbum 4 IsPublic <True/False>
        public override string Execute()
        {
            int albumId = int.Parse(Data[1]);
            string propToModify = Data[2];
            string newValue = Data[3];

            bool publicOrNot = true;
            if (newValue.ToLower() == "false")
            {
                publicOrNot = false;
            }
            Album albumToModify = this.unit.Albums.FirstOrDefaultWhere(a => a.Id == albumId);
            switch (propToModify.ToLower())
            {
                case "name":
                    albumToModify.Name = newValue;
                    return $"Album with Id = {albumId} changed name to {newValue}";
                case "ispublic":
                    albumToModify.IsPublic = publicOrNot;
                    return $"Album {albumToModify.Name}'s new IsPublic status is {newValue}";
                case "backgroundcolor":
                    albumToModify.BackgroundColor = (Color) Enum.Parse(typeof(Color), newValue, true);

                    return $"Album {albumToModify.Name} changed it's background color to {newValue}";
            }
            return null;
        }
    }
}