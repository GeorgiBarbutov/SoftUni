using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    class RemoveVillain
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlTransaction transaction = sqlConnection.BeginTransaction("removeVillain");

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection;
                    command.Transaction = transaction;

                    string villainName = CheckForVillain(villainId, command);
                    int minionsReleased = DeleteFromMinionsVillains(villainId, command);
                    DeleteFromVillains(villainId, command);

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsReleased} minions were released.");

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            sqlConnection.Close();
        }

        private static void DeleteFromVillains(int villainId, SqlCommand command)
        {
            command.CommandText = "DELETE FROM Villains WHERE Id = @villainId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@villainId", villainId);

            command.ExecuteNonQuery();
        }

        private static int DeleteFromMinionsVillains(int villainId, SqlCommand command)
        {
            command.CommandText = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@villainId", villainId);

            int minionsReleased = command.ExecuteNonQuery();
            return minionsReleased;
        }

        private static string CheckForVillain(int villainId, SqlCommand command)
        {
            command.CommandText = "SELECT v.Name FROM Villains AS v WHERE v.Id = @villainId";
            command.Parameters.AddWithValue("@villainId", villainId);

            string villainName = (string)command.ExecuteScalar();

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                throw new Exception();
            }

            return villainName;
        }
    }
}
