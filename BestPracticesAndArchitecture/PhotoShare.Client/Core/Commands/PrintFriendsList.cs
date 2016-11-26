namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class PrintFriendsListCommand : Command
    {
        public PrintFriendsListCommand(string[] data) : base(data)
        {
        }

        //PrintFriendsList <username>
        public override string Execute()
        {
            User desiredUser = this.unit.Users.FirstOrDefaultWhere(user => user.Username == Data[1]);
            return $"User {Data[1]} has the following friends - {string.Join(", ", desiredUser.Friends)}";
        }
    }
}