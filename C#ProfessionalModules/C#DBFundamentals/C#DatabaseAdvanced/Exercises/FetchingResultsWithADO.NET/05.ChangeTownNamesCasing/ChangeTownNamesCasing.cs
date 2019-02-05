using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    class ChangeTownNamesCasing
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlTransaction transaction = sqlConnection.BeginTransaction("changeTownNames");

                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection;
                    command.Transaction = transaction;

                    int countryId = GetCountryId(countryName, command);
                    int rowsAffected = UpdateTowns(command, countryId);

                    if (rowsAffected == 0)
                    {
                        throw new Exception();
                    }

                    Console.WriteLine($"{rowsAffected} town names were affected.");

                    List<string> townNames = new List<string>();
                    GetTownNames(command, countryId, townNames);

                    Console.WriteLine($"[" + String.Join(", ", townNames) + "]");

                    transaction.Commit();
                }
                catch
                {
                    Console.WriteLine("No town names were affected.");
                    transaction.Rollback();
                }
            }

            sqlConnection.Close();
        }

        private static void GetTownNames(SqlCommand command, int countryId, List<string> townNames)
        {
            command.CommandText = "SELECT t.Name FROM Towns AS t WHERE t.CountryCode = @countryId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@countryId", countryId);

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                townNames.Add((string)dataReader["Name"]);
            }
            dataReader.Close();
        }

        private static int UpdateTowns(SqlCommand command, int countryId)
        {
            command.CommandText = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode =  @countryId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@countryId", countryId);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        private static int GetCountryId(string countryName, SqlCommand command)
        {
            command.CommandText = "SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName";
            command.Parameters.AddWithValue("@countryName", countryName);

            int countryId = (int)command.ExecuteScalar();
            return countryId;
        }
    }
}
