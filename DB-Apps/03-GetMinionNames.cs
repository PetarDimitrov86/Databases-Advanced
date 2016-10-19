using System.Data.SqlClient;
using System;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=.\\; Database=MinionsDB; Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        using (connection)
        {
            string desiredID = Console.ReadLine();
            Selection(desiredID, connection);
        }
    }

    static void Selection(string desiredID, SqlConnection connection)
    {
        string villainInfoCommand = "SELECT v.Name FROM Villains AS v WHERE v.VillainID = ";
        SqlCommand command = new SqlCommand(villainInfoCommand + "(@id)", connection);
        command.Parameters.AddWithValue("@id", desiredID);
        Console.WriteLine($"Villain: {command.ExecuteScalar()}");      
        string minionBelongingToVillainCommand = " SELECT m.Name, m.Age FROM Villains AS v " +
                                         "INNER JOIN MinionsVillains AS mv " +
                                         "ON mv.VillainID = v.VillainID " +
                                         "INNER JOIN Minions AS m " +
                                         "ON m.MinionID = mv.MinionID " +
                                         "WHERE v.VillainID = ";
        command.CommandText = minionBelongingToVillainCommand + "@id";
        SqlDataReader reader = command.ExecuteReader();
        int counter = 1;
        while (reader.Read())
        {
            Console.WriteLine($"{counter}. {reader["Name"]} {reader["Age"]}");
            counter++;
        }
        reader.Close();
    }
}