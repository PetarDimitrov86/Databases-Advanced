namespace _09.IncreaseAgeStoredProcedure
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class IncreaseAgeStoredProcedure
    {
        public static string connectionString = "Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True";

        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand getOlder = new SqlCommand("usp_GetOlder", connection);
                getOlder.CommandType = CommandType.StoredProcedure;
                getOlder.Parameters.AddWithValue("@MinionId", minionId);

                connection.Open();

                getOlder.ExecuteNonQuery();

                SqlCommand minion = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @minionId", connection);
                minion.Parameters.AddWithValue("@minionId", minionId);
                using (SqlDataReader reader = minion.ExecuteReader())
                {
                    reader.Read();
                    Console.WriteLine(reader["Name"] + " " + reader["Age"]);
                }
            }
        }
    }
}
