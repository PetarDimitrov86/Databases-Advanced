using System;
using System.Data.SqlClient;

public class AddMinion
{
    static void Main()
    {
        string[] minionInfo = Console.ReadLine().Split();
        string[] villainInfo = Console.ReadLine().Split();
        string minionName = minionInfo[1];
        int minionAge = int.Parse(minionInfo[2]);
        string minionCity = minionInfo[3];
        string villainName = villainInfo[1];

        string connectionString = "Server=.\\; Database=MinionsDB; Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string villainPresenceCheckCommand = "SELECT v.Name FROM Villains AS v WHERE v.Name = '" + villainName + "' ";
        string townPresenceCheckCommand = "SELECT t.TownName FROM Towns AS t WHERE t.TownName = '" + minionCity + "' ";
        
        using (connection)
        {
            SqlCommand command = new SqlCommand(townPresenceCheckCommand, connection);
            if ((string)command.ExecuteScalar() != minionCity)
            {
                string addTownNameToDBCommand = "INSERT INTO Towns (TownName)" +
                                            "VALUES ('" +
                                             minionCity + "') ";
                command.CommandText = addTownNameToDBCommand;
                command.ExecuteNonQuery();
                Console.WriteLine($"Town {minionCity} was added to the database.");
            }
            command.CommandText = villainPresenceCheckCommand;
            if ((string)command.ExecuteScalar() != villainName)
            {
                string addVillainToDBCommand = "INSERT INTO Villains (Name, EvilnessFactor) " +
                                            "VALUES ('" +
                                            villainName + "', 'evil') ";
                command.CommandText = addVillainToDBCommand;
                command.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            command.CommandText = "SELECT t.TownID FROM Towns AS t WHERE t.TownName = '" + minionCity + "' ";
            int cityID = (int)command.ExecuteScalar();
            command.CommandText = "INSERT INTO Minions (Name, Age, TownID) " +
                                  "VALUES ('" +
                                  minionName + "', '" + minionAge + "', '" + cityID + "') ";
            command.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
            command.CommandText = "SELECT m.MinionID FROM Minions AS m WHERE m.Name = '" +
                                    minionName + "' ";
            int minionID = (int)command.ExecuteScalar();
            command.CommandText = "SELECT v.VillainID FROM Villains AS v WHERE v.Name = '" +
                                    villainName + "' ";
            int villainID = (int)command.ExecuteScalar();
            command.CommandText = "INSERT INTO MinionsVillains (MinionID, VillainID) " +
                                  "VALUES (" +
                                  minionID + ", " + villainID + ") ";
            command.ExecuteNonQuery();




        }


    }
}