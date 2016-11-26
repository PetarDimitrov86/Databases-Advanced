namespace PhotoShare.Client.Core.Commands
{
    using Models;

    public class AddTownCommand : Command
    {
        public AddTownCommand(string[] data) : base(data)
        {
        }

        //AddTown <townName> <countryName>
        public override string Execute()
        {
            string townName = Data[1];
            string country = Data[2];

            Town town = new Town()
            {
                Name = townName,
                Country = country
            };

            this.unit.Towns.Add(town);

            return townName + " was added to database";
        }
    }
}
