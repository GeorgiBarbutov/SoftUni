using System;
using System.Data.SqlClient;

namespace AddMinion
{
    class AddMinion
    {
        static void Main(string[] args)
        {
            GetInput(out string minionName, out int minionAge, out string townName, out string villainName);

            string connectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                try
                {
                    SqlCommand getTownCommand = InsertIntoTowns(townName, sqlConnection, transaction);
                    int townId = GetTownId(getTownCommand);

                    SqlCommand getVillainCommand = InsertIntoVillains(villainName, sqlConnection, transaction);
                    int villainId = GetVillainId(getVillainCommand);

                    InsertIntoMinions(minionName, minionAge, sqlConnection, transaction, townId);
                    int minionId = GetMinionId(minionName, sqlConnection, transaction);

                    InsertIntMinionsTowns(minionName, villainName, sqlConnection, transaction, villainId, minionId);

                    transaction.Commit();
                }
                catch
                {
                    Console.WriteLine("Something went wrong Boiiii");
                    transaction.Rollback();
                }
            }

            sqlConnection.Close();
        }

        private static void InsertIntMinionsTowns(string minionName, string villainName, SqlConnection sqlConnection, SqlTransaction transaction, int villainId, int minionId)
        {
            SqlCommand insertIntoMinionsVillainsCommand = new SqlCommand();
            insertIntoMinionsVillainsCommand.CommandText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
            insertIntoMinionsVillainsCommand.Parameters.AddWithValue("@minionId", minionId);
            insertIntoMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);
            insertIntoMinionsVillainsCommand.Connection = sqlConnection;
            insertIntoMinionsVillainsCommand.Transaction = transaction;

            insertIntoMinionsVillainsCommand.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinionId(string minionName, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            SqlCommand getMinionCommand = new SqlCommand();
            getMinionCommand.CommandText = "SELECT TOP(1) m.Id FROM Minions AS m WHERE m.Name = @minionName ORDER BY m.Id DESC";
            getMinionCommand.Parameters.AddWithValue("@minionName", minionName);
            getMinionCommand.Connection = sqlConnection;
            getMinionCommand.Transaction = transaction;

            int minionId = (int)getMinionCommand.ExecuteScalar();
            return minionId;
        }

        private static void InsertIntoMinions(string minionName, int minionAge, SqlConnection sqlConnection, SqlTransaction transaction, int townId)
        {
            string insertMinionCommandText = "INSERT INTO Minions ([Name], Age, TownId) VALUES (@minionName, @minionAge, @townId)";
            SqlCommand insertMinionCommand = new SqlCommand(insertMinionCommandText, sqlConnection);
            insertMinionCommand.Parameters.AddWithValue("@minionName", minionName);
            insertMinionCommand.Parameters.AddWithValue("@minionAge", minionAge);
            insertMinionCommand.Parameters.AddWithValue("@townId", townId);
            insertMinionCommand.Transaction = transaction;

            insertMinionCommand.ExecuteNonQuery();
        }

        private static int GetVillainId(SqlCommand getVillainCommand)
        {
            getVillainCommand.CommandText = "SELECT v.Id FROM Villains AS v WHERE v.Name = @villainName";
            int villainId = (int)getVillainCommand.ExecuteScalar();
            return villainId;
        }

        private static SqlCommand InsertIntoVillains(string villainName, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string getVillainCommandText = "SELECT v.Name FROM Villains AS v WHERE v.Name = @villainName";
            SqlCommand getVillainCommand = new SqlCommand(getVillainCommandText, sqlConnection);
            getVillainCommand.Parameters.AddWithValue("@villainName", villainName);
            getVillainCommand.Transaction = transaction;

            string villain = (string)getVillainCommand.ExecuteScalar();
            if (villain == null)
            {
                string insertVillainCommandText = "INSERT INTO Villains ([Name], EvilnessFactorId) VALUES (@villainName, 4)";
                SqlCommand insertVillainCommand = new SqlCommand(insertVillainCommandText, sqlConnection);
                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCommand.Transaction = transaction;

                insertVillainCommand.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            return getVillainCommand;
        }

        private static void GetInput(out string minionName, out int minionAge, out string townName, out string villainName)
        {
            string[] minionInput = Console.ReadLine().Split(" ");

            minionName = minionInput[1];
            minionAge = int.Parse(minionInput[2]);
            townName = minionInput[3];
            string[] villainInput = Console.ReadLine().Split(" ");
            villainName = villainInput[1];
        }

        private static int GetTownId(SqlCommand getTownCommand)
        {
            getTownCommand.CommandText = "SELECT t.Id FROM Towns AS t WHERE t.Name = @townName";
            int townId = (int)getTownCommand.ExecuteScalar();
            return townId;
        }

        private static SqlCommand InsertIntoTowns(string townName, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string getTownCommandText = "SELECT t.Name FROM Towns AS t WHERE t.Name = @townName";
            SqlCommand getTownCommand = new SqlCommand(getTownCommandText, sqlConnection);
            getTownCommand.Parameters.AddWithValue("@townName", townName);
            getTownCommand.Transaction = transaction;

            string town = (string)getTownCommand.ExecuteScalar();

            if (town == null)
            {
                string insertTownCommandText = "INSERT INTO Towns ([Name]) VALUES (@townName)";
                SqlCommand insertTownCommand = new SqlCommand(insertTownCommandText, sqlConnection);
                insertTownCommand.Parameters.AddWithValue("@townName", townName);
                insertTownCommand.Transaction = transaction;

                insertTownCommand.ExecuteNonQuery();

                Console.WriteLine($"Town {townName} was added to the database.");
            }

            return getTownCommand;
        }
    }
}
