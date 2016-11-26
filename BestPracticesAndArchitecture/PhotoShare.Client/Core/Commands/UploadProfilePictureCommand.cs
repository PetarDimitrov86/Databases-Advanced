namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class UploadProfilePictureCommand : Command
    {

        public UploadProfilePictureCommand(string[] data) : base(data)
        {
        }

        //UploadProfilePicture <username> <pictureFilePath>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}