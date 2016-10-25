namespace _04.AddMinion
{
    using System;
    using System.Data.SqlClient;

    class AddMinion
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main()
        {
            //read input
            var readLine = Console.ReadLine();
            if (readLine != null)
            {                                              
                string[] minionTokens = readLine.Split();
                string minionName = minionTokens[1];
                int minionAge = int.Parse(minionTokens[2]);
                string minionTown = minionTokens[3];
                string[] villainTokens = readLine.Split();
                string villainName = villainTokens[1];

                string townSQL = "SELECT Id FROM towns WHERE name = @townName";
                SqlCommand cmd = new SqlCommand(townSQL, Connection);
                cmd.Parameters.AddWithValue("@townName", minionTown);
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
            
                if (!reader.HasRows)
                {
                    //add town to db
                    reader.Close();
                    string addTownSQL = "INSERT INTO towns (name, country) VALUES (@townName, NULL)";
                    SqlCommand addTown = new SqlCommand(addTownSQL, Connection);
                    addTown.Parameters.AddWithValue("@townName", minionTown);
                    addTown.ExecuteNonQuery();
                    Console.WriteLine("Town {0} was added to the database.", minionTown);
                }
                reader.Close();

                int townId = (int)cmd.ExecuteScalar();
                reader.Close();
            
                string villainSQL = "SELECT * FROM villains WHERE name = @villainName";
                SqlCommand getVillain = new SqlCommand(villainSQL, Connection);
                getVillain.Parameters.AddWithValue("@villainName", villainName);
                reader = getVillain.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    string addVillainSQL = "INSERT INTO villains (name, EvilnessFactor) VALUES (@villainName, 'evil')";
                    SqlCommand addVillain = new SqlCommand(addVillainSQL, Connection);
                    addVillain.Parameters.AddWithValue("@villainName", villainName);
                    addVillain.ExecuteNonQuery();
                    Console.WriteLine("Villain {0} was added to the database.", villainName);
                }
                reader.Close();

                int villainId = (int)getVillain.ExecuteScalar();
                reader.Close();

                //add minion
                string addMinionSQL = "INSERT INTO minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                SqlCommand addMinion = new SqlCommand(addMinionSQL, Connection);
                addMinion.Parameters.AddWithValue("@name", minionName);
                addMinion.Parameters.AddWithValue("@age", minionAge);
                addMinion.Parameters.AddWithValue("@townId", townId);
                addMinion.ExecuteNonQuery();

                //get minion id
                string getMinionIdSQL = "SELECT id FROM minions where name = @minionName";
                SqlCommand getMinion = new SqlCommand(getMinionIdSQL, Connection);
                getMinion.Parameters.AddWithValue("@minionName", minionName);
                int minionId = (int)getMinion.ExecuteScalar();


                //add record in MinionsVillains table
                string addMinionToVillainSQL = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                SqlCommand addMinionToVillain = new SqlCommand(addMinionToVillainSQL, Connection);
                addMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
                addMinionToVillain.Parameters.AddWithValue("@villainId", villainId);
                addMinionToVillain.ExecuteNonQuery();

                Console.WriteLine("Successfully added {0} to be minion of {1}", minionName, villainName);
            }
        }
    }
}
