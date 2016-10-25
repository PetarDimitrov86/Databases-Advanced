namespace _02.GetVillainsNames
{
    using System;
    using System.Data.SqlClient;

    class GetVillainsNames
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        public static void Main()
        {

            SqlCommand cmd = new SqlCommand("SELECT v.Name, COUNT(MinionId) AS c\n" +
                    "FROM Villains v\n" +
                    "JOIN MinionsVillains mv ON v.Id = mv.VillainId\n" +
                    "GROUP BY v.Name\n" +
                    "HAVING COUNT(MinionId) > 1\n" +
                    "ORDER BY c DESC", Connection);
            Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]+" "+reader[1]);
                }
            }
            Connection.Close();

        }
    }
}
