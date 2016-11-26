namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class DeleteUser : Command
    {
        public DeleteUser(string[] data) : base(data)
        {
        }

        //DeleteUser <username>
        public override string Execute()
        {
            //TODO Delete User by username (only mark him as inactive)
            string username = Data[1];
            var user = this.unit.Users.FirstOrDefaultWhere(u => u.Username == username);

            if(user == null)
            {
                throw new InvalidOperationException($"User with {username} was not found");
            }

            user.IsDeleted = true;

            return $"User {username} was deleted from the databse"; 
        }
    }
}