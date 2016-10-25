namespace _03.GetMinionNames
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class GetMinionNames
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main()
        {
            int id = int.Parse(Console.ReadLine());
            string villainNameSQL = "SELECT Name FROM Villains WHERE id = @villainId";
            SqlCommand cmd = new SqlCommand(villainNameSQL, Connection);
            cmd.Parameters.AddWithValue("@villainId", id);
            Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("No villain with ID "+ id +" exists in the database.");
                    return;
                }
                reader.Read();
                string villainName = reader[0].ToString();
                Console.WriteLine("Villain: " + villainName);

            }
            Connection.Close();

            string minionsSQL = "select m.name, age\n" +
                    "FROM Villains v\n" +
                    "JOIN MinionsVillains mv ON v.Id = mv.VillainId\n" +
                    "JOIN Minions m ON m.id = mv.MinionId\n" +
                    "WHERE v.Id = @villainId";
            cmd = new SqlCommand(minionsSQL, Connection);
            cmd.Parameters.AddWithValue("@villainId", id);
            Connection.Open();
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("<no minions>");
                    return;
                }

                int counter = 1;
                while (reader.Read())
                {
                    Console.WriteLine(counter + " " + reader["name"]+" "+reader["age"]);
                    counter++;
                }
            }
            Connection.Close();
        }
    }
}
