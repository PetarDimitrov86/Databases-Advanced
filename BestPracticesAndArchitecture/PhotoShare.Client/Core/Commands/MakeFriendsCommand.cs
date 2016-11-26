namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class MakeFriendsCommand : Command
    {
        public MakeFriendsCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            //bidirectional adding friends
            //MakeFriends <username1> <username2>
            string firstUsername = Data[1];
            string secondUsername = Data[2];

            User firstUser = this.unit.Users.FirstOrDefaultWhere(u => u.Username == firstUsername);
            User secondUser = this.unit.Users.FirstOrDefaultWhere(u => u.Username == secondUsername);

            firstUser.Friends.Add(secondUser);
            secondUser.Friends.Add(firstUser);

            return $"{firstUsername} is now friends with {secondUsername} and {secondUsername} is also friends with {firstUsername}!";
        }
    }
}