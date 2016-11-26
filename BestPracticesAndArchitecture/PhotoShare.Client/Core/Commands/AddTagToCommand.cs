namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class AddTagToCommand : Command
    {
        public AddTagToCommand(string[] data) : base(data)
        {
        }

        //AddTagTo <albumName> <tag>
        public override string Execute()
        {
            string albumName = Data[1];
            string tag = Data[2].ValidateOrTransform();

            Album album = this.unit.Albums
                                    .FirstOrDefaultWhere(al => al.Name == albumName);

            if (album == null)
            {
                return "No such album name exists";
            }

            album.Tags.Add(new Tag
            {
                Name = tag
            });

            return tag + " was added sucessfully to album " + albumName;
        }
    }
}
