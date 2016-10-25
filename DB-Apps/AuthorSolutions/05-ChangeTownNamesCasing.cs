namespace _05.ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;       
    using System.Data.SqlClient;
    using System.Text;

    class ChangeTownNamesCasing
    {
        public static string ConnectionString = "Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True";

        static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string country = Console.ReadLine();
                SqlCommand townSelectionCommand = new SqlCommand("SELECT [Name] FROM Towns " +
                                                                 "WHERE Country = @countryName", connection);
                townSelectionCommand.Parameters.AddWithValue("@countryName", country);

                SqlDataReader townsReader = townSelectionCommand.ExecuteReader();
                List<string> towns = new List<string>();
                while (townsReader.Read())
                {
                    towns.Add((string)townsReader[0]);
                }
                townsReader.Close();

                List<string> townsChanged = new List<string>();
                foreach (string town in towns)
                {
                    if (town != town.ToUpper())
                    {
                        townsChanged.Add(town.ToUpper());
                        SqlCommand updateCommand = new SqlCommand("UPDATE Towns " +
                                                                  "SET Name = @upperName " +
                                                                  "WHERE Name = @townName", connection);
                        updateCommand.Parameters.AddWithValue("@upperName", town.ToUpper());
                        updateCommand.Parameters.AddWithValue("@townName", town);
                        updateCommand.ExecuteNonQuery();
                    }
                }

                StringBuilder townsRow = new StringBuilder();
                if (townsChanged.Count != 0)
                {
                    townsRow.AppendLine($"{townsChanged.Count} towns were affected.");
                    townsRow.AppendLine($"[{String.Join(", ", townsChanged)}]");
                }
                else
                {
                    townsRow.AppendLine("No town names were affected.");
                }

                Console.WriteLine(townsRow.ToString());
            }
        }
    }
}
