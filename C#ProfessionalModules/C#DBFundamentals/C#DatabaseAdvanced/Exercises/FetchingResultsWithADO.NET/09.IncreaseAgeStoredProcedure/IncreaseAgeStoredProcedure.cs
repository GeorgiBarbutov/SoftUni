using System;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class IncreaseAgeStoredProcedure
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Server=COMP14415\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

            sqlConnection.Open();

            using (sqlConnection)
            {
                int inputId = int.Parse(Console.ReadLine());

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                ExecuteProcedure(inputId, sqlCommand);
                PrintNameAndAge(inputId, sqlCommand);
            }

            sqlConnection.Close();
        }

        private static void PrintNameAndAge(int inputId, SqlCommand sqlCommand)
        {
            sqlCommand.CommandText = "SELECT m.Name, m.Age FROM Minions AS m WHERE m.Id = @minionId";
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@minionId", inputId);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Console.WriteLine(String.Concat(sqlDataReader["Name"], " - ", sqlDataReader["Age"], " years old"));
            }
            sqlDataReader.Close();
        }

        private static void ExecuteProcedure(int inputId, SqlCommand sqlCommand)
        {
            sqlCommand.CommandText = "EXEC dbo.usp_GetOlder @minionId";
            sqlCommand.Parameters.AddWithValue("@minionId", inputId);

            sqlCommand.ExecuteNonQuery();
        }
    }
}
