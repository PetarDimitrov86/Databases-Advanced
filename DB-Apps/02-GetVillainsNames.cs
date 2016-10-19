using System;
using System.Data.SqlClient;

public class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=.\\; Database=MinionsDB; Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string queryCommandString = "SELECT v.Name, COUNT(*) AS NumOfMinions FROM Villains AS v " +
                                    "INNER JOIN MinionsVillains AS mv " +
                                    "ON v.VillainID = mv.VillainID " +
                                    "GROUP BY v.Name " +
                                    "HAVING COUNT(*) > 3 " +
                                    "ORDER BY COUNT(*) DESC ";
        SqlCommand command = new SqlCommand(queryCommandString, connection);
        using (connection)
        {
            using (connection)
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} ");
                    }
                    Console.WriteLine();
                    //Console.WriteLine($"{reader["Name"]} {reader["NumOfMinions"]}");
                }
            }
            connection.Close();
        }
    }
}