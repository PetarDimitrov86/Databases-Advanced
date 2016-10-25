namespace _08.IncreaseMinionAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;                       
    using System.Text;

    class IncreaseMinionAge
    {
        public static string ConnectionString = "Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True";

        static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    int[] ids = readLine.Split(' ').Select(int.Parse).ToArray();
                    var updateCommandString = GetBuildCommand(ids);

                    SqlCommand updateCommand = new SqlCommand(updateCommandString.ToString(), connection);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        updateCommand.Parameters.AddWithValue(@"minionId" + i, ids[i]);
                    }

                    updateCommand.ExecuteNonQuery();
                }

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Minions", connection);
                SqlDataReader minionsReader = selectCommand.ExecuteReader();
                while (minionsReader.Read())
                {
                    for (int i = 0; i < minionsReader.FieldCount; i++)
                    {
                        Console.Write($"{minionsReader[i]} ");
                    }   
                    Console.WriteLine();
                }
            }

        }

        private static StringBuilder GetBuildCommand(int[] ids)
        {
            StringBuilder commandBuilder = new StringBuilder();
            for (int i = 0; i < ids.Length; i++)
            {
                commandBuilder.AppendLine("UPDATE Minions " +
                                          "SET Age = Age + 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)) " +
                                          "WHERE ID = @minionId" + i);
                commandBuilder.AppendLine();
            }
            return commandBuilder;
        }
    }
}
