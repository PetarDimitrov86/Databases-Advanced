using System.Data.SqlClient;

public class InitialSetup
{
    static void Main()
    {
        string connectionString = "Server=.\\; Database=master; Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        using (connection)
        {
            string createDatabaseCommandString = "CREATE DATABASE MinionsDB";
            string createMinionsTableString = "CREATE TABLE Minions " +
                                            "(" +
                                            "MinionID INT PRIMARY KEY IDENTITY, " +
                                            "Name VARCHAR(50), " +
                                            "Age INT, " +
                                            "TownID INT, " +
                                            "FOREIGN KEY (TownID) REFERENCES Towns(TownID) " +
                                            ") ";
            string createTownsTableString = "USE MinionsDB " + "CREATE TABLE Towns " +
                                            "(" +
                                            "TownId INT PRIMARY KEY IDENTITY, " +
                                            "TownName VARCHAR(50) NOT NULL, " +
                                            "Country VARCHAR(50) " +
                                            ") ";
            string createVillainsTableString = "CREATE TABLE Villains " +
                                            "(" +
                                            "VillainID INT PRIMARY KEY IDENTITY, " +
                                            "Name VARCHAR(50), " +
                                            "EvilnessFactor VARCHAR(50), " +
                                            ")";

            string createMinionsVillainsTableString = "CREATE TABLE MinionsVillains " +
                                            "(" +
                                            "MinionID INT, " +
                                            "VillainID INT, " +
                                            "PRIMARY KEY (MinionID, VillainID), " +
                                            "FOREIGN KEY (MinionID) REFERENCES Minions(MinionID), " +
                                            "FOREIGN KEY (VillainID) REFERENCES Villains(VillainID) " + ")";
            string insertMinionsCommandString = "INSERT INTO Minions (Name, Age, TownID) " +
                            "VALUES " +
                            "('Bob', 13, 1), ('Kevin', 14, 2), ('Steward', 19, 3), ('Petar', 30, 5), ('Lidiya', 22, 1) ";
            string insertTownsCommandString = "INSERT INTO Towns (TownName, Country) " +
                            "VALUES " +
                            "('Sofia', 'Bulgaria'), ('Berlin', 'Germany'), ('Eindhoven', 'Netherlands'), ('Liverpool','England'), ('Pleven', 'Bulgaria') ";
            string insertVillainsCommandString = "INSERT INTO Villains (Name, EvilnessFactor) " +
                            "VALUES " +
                            "('Gru', 'super evil'), ('Victor', 'evil'), ('Victor Jr', 'good'), ('Spongebob','bad'), ('Doofenschmurtz', 'good') ";
            string insertMinionsVillansCommandString = "INSERT INTO MinionsVillains (MinionID, VillainID) " +
                            "VALUES " +
                            "(1, 1), (2, 1), (3, 1), (4, 5), (5, 4) ";
            SqlCommand command = new SqlCommand(createDatabaseCommandString, connection);

            using (connection)
            {
                command.ExecuteNonQuery();
                command.CommandText = createTownsTableString;
                command.ExecuteNonQuery();
                command.CommandText = createMinionsTableString;
                command.ExecuteNonQuery();
                command.CommandText = createVillainsTableString;
                command.ExecuteNonQuery();
                command.CommandText = createMinionsVillainsTableString;
                command.ExecuteNonQuery();
                command.CommandText = insertTownsCommandString;
                command.ExecuteNonQuery();
                command.CommandText = insertMinionsCommandString;
                command.ExecuteNonQuery();
                command.CommandText = insertVillainsCommandString;
                command.ExecuteNonQuery();
                command.CommandText = insertMinionsVillansCommandString;
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
