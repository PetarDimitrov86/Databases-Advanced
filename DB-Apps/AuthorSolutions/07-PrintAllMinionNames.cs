namespace _07.PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class PrintAllMinionNames
    {
        public static string ConnectionString = "Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True";

        static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand minionNames = new SqlCommand("SELECT Name FROM Minions", connection);
                connection.Open();
                using (SqlDataReader reader = minionNames.ExecuteReader())
                {
                    List<string> names = new List<string>();
                    while (reader.Read())
                    {
                        names.Add(reader["Name"].ToString());
                    }

                    PrintNames(names);
                }
            }

            
        }

        static void PrintNames(IList<string> names)
        {
            int firstIndex = 0;
            int lastIndex = names.Count - 1;

            for (int i = 0; i < names.Count; i++)
            {
                int currentIndex;
                if (i % 2 == 0)
                {
                    currentIndex = firstIndex;
                    firstIndex++;
                }
                else
                {
                    currentIndex = lastIndex;
                    lastIndex--;
                }

                Console.WriteLine(names[currentIndex]);
            }
        }
    }
}
