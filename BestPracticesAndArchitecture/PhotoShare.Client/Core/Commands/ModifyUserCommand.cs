namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class ModifyUserCommand : Command
    {
        public ModifyUserCommand(string[] data) : base(data)
        {
        }

        //ModifyUser <username> <property> <new value>
        //For example:
        //ModifyUser <username> Password <NewPassword>
        //ModifyUser <username> Email <NewEmail>
        //ModifyUser <username> FirstName <NewFirstName>
        //ModifyUser <username> LastName <newLastName>
        //ModifyUser <username> BornTown <newBornTownName>
        //ModifyUser <username> CurrentTown <newCurrentTownName>
        //!!! Cannot change username
        public override string Execute()
        {
            string username = Data[1];
            string propToModify = Data[2];
            string newValue = Data[3];

            User userToModify = this.unit.Users.FirstOrDefaultWhere(u => u.Username == username);

            switch (propToModify.ToLower())
            {
                case "password":
                    userToModify.Password = newValue;
                    return $"User {userToModify.Username} changed his/her password to {new string('*', newValue.Length)}.";
                case "email":
                    userToModify.Email = newValue;
                    return $"User {userToModify.Username} changed his/her email to {newValue}.";
                case "firstname":
                    userToModify.FirstName = newValue;
                    return $"User {userToModify.Username} changed his/her first name to {newValue}.";
                case "lastname":
                    userToModify.LastName = newValue;
                    return $"User {userToModify.Username} changed his/her last name to {newValue}.";
                case "borntown":
                    Town bornTown = this.unit.Towns.FirstOrDefaultWhere(t => t.Name == newValue);
                    userToModify.BornTown = bornTown;
                    return $"User {userToModify.Username} changed his/her born town to {newValue}.";
                case "currenttown":
                    Town currentTown = this.unit.Towns.FirstOrDefaultWhere(t => t.Name == newValue);
                    userToModify.CurrentTown = currentTown;
                    return $"User {userToModify.Username} changed his/her current town to {newValue}.";
                case "age":
                    userToModify.Age = int.Parse(newValue);
                    return $"User {userToModify.Username} is now {newValue} years old.";
            }
            return string.Empty;
        }
    }
}