namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class UploadPictureCommand : Command
    {

        public UploadPictureCommand(string[] data) : base(data)
        {
        }

        //UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}